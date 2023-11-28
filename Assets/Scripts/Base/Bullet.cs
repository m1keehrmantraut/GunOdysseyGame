using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float distance;
    private float playerDamage = 20f;
    public int enemyDamage = 5;
    public LayerMask whatIsSolid;
    public GameObject destroyEffect;

    private GameObject player;
    private float boost;
    
    [SerializeField] bool enemyBullet;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if(hitInfo.collider != null)
        {
            if(hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<EnemyHealth>().TakeDamageEnemy(playerDamage + playerDamage * boost);
            }
            
            if(hitInfo.collider.CompareTag("Player") && enemyBullet)
            {
                hitInfo.collider.GetComponent<BaseHealth>().TakeDamage(enemyDamage);
            }
            DestroyBullet();
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    public void DestroyBullet()
    {
        // GameObject im = Instantiate(destroyEffect, transform.position, Quaternion.identity);
        // Destroy(im, 1f);
        Destroy(gameObject);
    }
    
    public void IncreaseBoost(float velocity)
    {
        boost += velocity;
        Debug.Log("inc");
    }
}
