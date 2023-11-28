using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shotPoint;

    [SerializeField] private AudioClip laserShot;
    [SerializeField] private AudioSource audioSource;
    
    private BaseHealth player;
    private Vector3 difference;
    
    private float offset = -90f;
    private float rotZ;
    private float distance = 7f;

    private float timeBtwShots = 1f;
    private bool shootStatus = true;

    private bool actic;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<BaseHealth>();
    }
    
    IEnumerator ShootTime(float timeBtwShots)
    {
        shootStatus = false;
        yield return new WaitForSeconds(timeBtwShots);
        shootStatus = true;
    }
    
    void FixedUpdate()
    {
        difference = player.transform.position - transform.position;
        rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        Shoot();
    }
    
    public void Shoot()
    {
        if (shootStatus && actic)
        {
            if (Vector3.Distance(transform.position, player.transform.position)
                <= distance)
            {
                audioSource.Play();
                Instantiate(bullet, shotPoint.position, shotPoint.rotation);
                StartCoroutine(ShootTime(timeBtwShots));
            }
        }
    }

    public void StartShooting()
    {
        actic = true;
    }
}
