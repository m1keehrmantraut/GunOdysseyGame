using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int enemyDamage = 10;
    // public GameObject hitEffect;
    // public GameObject impactEffect; 
    
    private WavesSystem wave;

    private void Start()
    {
        wave = GameObject.FindWithTag("Wave").GetComponent<WavesSystem>();
    }
    
    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        BaseHealth player = hitInfo.GetComponent<BaseHealth>();
        if (player != null)
        {
            player.TakeDamage(enemyDamage);
        }

        // GameObject imEffect = Instantiate(impactEffect, transform.position, transform.rotation);
        // Destroy(imEffect, 1f);
        Destroy(gameObject);
    }
}