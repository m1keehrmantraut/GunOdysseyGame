using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject PlayerBase;
    private float speed = 3f;

    private EnemyShooting enemy;
    
    void Start()
    {
        PlayerBase = GameObject.FindWithTag("Player");
        enemy = gameObject.GetComponent<EnemyShooting>();
    }
    
    void Update()
    {
        float distance = Vector2.Distance(transform.position, PlayerBase.transform.position);

        if (distance > 5f)
        {
            enemy.StartShooting();        
            transform.Translate(Vector2.up * speed * Time.deltaTime);    
        }
        
    }
}
