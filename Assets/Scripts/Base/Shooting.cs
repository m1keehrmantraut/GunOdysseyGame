using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("Shoot Logic")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private LayerMask enemyLayers;
    
    [Header("Sounds")]
    [SerializeField] private AudioClip hitSound;
    private AudioSource audioSource;

    private bool activeShoot = false;
    
    private GameObject enemy;

    private bool shootStatus = true;

    private Following following;

    private float timeBtwShots = 0.1f;

    private void Awake()
    {
        audioSource = GameObject.FindGameObjectWithTag("ShootEffect").GetComponent<AudioSource>();
        following = gameObject.GetComponent<Following>();
    }
    

    IEnumerator ShootTime(float timeBtwShots)
    {
        shootStatus = false;
        yield return new WaitForSeconds(timeBtwShots);
        shootStatus = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();    
        }
        
    }

    private void Shoot()
    {
        if (shootStatus && activeShoot)
        {
            Instantiate(bullet, shotPoint.position, shotPoint.rotation);
            audioSource.Play(); 

            StartCoroutine(ShootTime(timeBtwShots));
        }
    }

    public void ChangeGunMode(bool isActivation)
    {
        if (isActivation)
        {
            activeShoot = true;
            following.ChangeMode(true);
        }
        else
        {
            activeShoot = false;
            following.ChangeMode(false);
        }
    }

    public void UpgradeDamage()
    {
        bullet.GetComponent<Bullet>().IncreaseBoost(0.7f);
    }
}
