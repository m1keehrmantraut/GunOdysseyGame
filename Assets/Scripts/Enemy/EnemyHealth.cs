using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private bool isEnemy;
    private Money money;
    
    private ScoreSystem score;

    public float healthEnemy = 100f;

    private BaseHealth baseHealth;
    // [SerializeField] GameObject deathEffect;

    private void Start()
    {
        baseHealth = GameObject.FindWithTag("Player").GetComponent<BaseHealth>();
        score = GameObject.FindWithTag("Score").GetComponent<ScoreSystem>();
        money = GameObject.FindWithTag("Player").GetComponent<Money>();
    }

    public void TakeDamageEnemy(float damage)
    {
        healthEnemy -= damage;
        
        if (healthEnemy <= 0)
        {
            DieEnemy();
        }
    }
    
    IEnumerator HitTime()
    {
        yield return new WaitForSeconds(0.5f);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            baseHealth.TakeDamage(20);
            Destroy(gameObject);    
        }
    }

    public void DieEnemy ()
    {
        if (isEnemy)
        {
            money.LootMoney();
        }
        else
        {
            money.LootResources();
        }
        score.AddScore(100);
        Destroy(gameObject);
    }
}
