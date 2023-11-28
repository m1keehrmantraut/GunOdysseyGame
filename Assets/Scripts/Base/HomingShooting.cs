using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingShooting : MonoBehaviour
{
    [Header("Shoot Logic")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shotPoint;

    [Header("Sounds")]
    // [SerializeField] private AudioClip hitSound;
    // private AudioSource audioSource; 

    private bool activeShoot = false;

    private bool shootStatus = true;

    private float timeBtwShots = 20f;

    private void Awake()
    {
        // audioSource = GameObject.FindGameObjectWithTag("ShootEffect").GetComponent<AudioSource>();
    }
    

    IEnumerator ShootTime(float timeBtwShots)
    {
        shootStatus = false;
        yield return new WaitForSeconds(timeBtwShots);
        shootStatus = true;
    }
    
    void FixedUpdate()
    {
        Shoot();
    }
    
    private void Shoot()
    {
        if (shootStatus && activeShoot)
        {
            // audioSource.Play(); 
            Instantiate(bullet, shotPoint.position, shotPoint.rotation);
            StartCoroutine(ShootTime(timeBtwShots));
        }
    }

    public void ChangeGunMode(bool isActivation)
    {
        if (isActivation)
        {
            activeShoot = true;
        }
        else
        {
            activeShoot = false;
        }
    }
    
    public void DecreaseTime()
    {
        timeBtwShots -= 4f;
    }
}