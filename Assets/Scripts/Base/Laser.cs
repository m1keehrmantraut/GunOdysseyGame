using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Laser : MonoBehaviour
{
    
    // this class was inspired by JOJO
    
    [SerializeField] private Camera cam;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject startVFX;
    [SerializeField] private GameObject endVFX;

    [SerializeField] private AudioSource _audioSource;
    
    private Following following;

    private Quaternion rotation;
    private List<ParticleSystem> particles = new List<ParticleSystem>();

    private bool shootStatus = true;

    private float timeBtwShoots = 0.5f;
    
    private float damage = 50f;

    private bool isActivation = false;

    private float boost = 1f;
    
    void Start()
    {
        following = gameObject.GetComponent<Following>();
        FillLists();
        DisableLaser();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && isActivation)
        {
            EnableLaser();
            _audioSource.Play();
        }
        
        if (Input.GetButton("Fire1") && isActivation)
        {
            UpdateLaser();
            
        }
        
        if (Input.GetButtonUp("Fire1"))
        {
            DisableLaser();
            _audioSource.Stop();
        }

        if (!isActivation)
        {
            DisableLaser();
        }
    }

    void EnableLaser()
    {
        lineRenderer.enabled = true;

        for (int i = 0; i < particles.Count; i++)
        {
            particles[i].Play();
        }
    }

    IEnumerator ShootTime(float timeBtwShots)
    {
        shootStatus = false;
        yield return new WaitForSeconds(timeBtwShots);
        shootStatus = true;
    }
    
    void UpdateLaser()
    {
        var mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        
        lineRenderer.SetPosition(0, (Vector2)firePoint.position);
        startVFX.transform.position = (Vector2)firePoint.position;

        lineRenderer.SetPosition(1, mousePos);
        

        Vector2 direction = mousePos - (Vector2)transform.position;
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, direction.normalized, direction.magnitude);

        if (hit)
        {
            lineRenderer.SetPosition(1, hit.point);
            if(hit.collider.CompareTag("Meteor"))
            {
                if (shootStatus && isActivation)
                {
                    Debug.Log("hoo");
                    hit.collider.GetComponent<EnemyHealth>().TakeDamageEnemy(damage * boost);
                    StartCoroutine(ShootTime(timeBtwShoots));    
                }
            }
        }

        endVFX.transform.position = lineRenderer.GetPosition(1);
    }

    void DisableLaser()
    {
        lineRenderer.enabled = false;
        
        for (int i = 0; i < particles.Count; i++)
        {
            particles[i].Stop();
        }
    }

    void FillLists()
    {
        for (int i = 0; i < startVFX.transform.childCount; i++)
        {
            var ps = startVFX.transform.GetChild(i).GetComponent<ParticleSystem>();
            if (ps != null)
            {
                particles.Add(ps);
            }
        }
        
        for (int i = 0; i < endVFX.transform.childCount; i++)
        {
            var ps = endVFX.transform.GetChild(i).GetComponent<ParticleSystem>();
            if (ps != null)
            {
                particles.Add(ps);
            }
            
        }
    }

    public void ChangeLaserMode(bool isActive)
    {
        if (isActive)
        {
            isActivation = true;
            following.ChangeMode(true);
        }
        else
        {
            isActivation = false;
            following.ChangeMode(false);
        }
    }

    public void StopLaser()
    {
        DisableLaser();
        isActivation = false;
    }

    public void UpgradeLaser(float velocity)
    {
        boost += velocity;
    }
}
