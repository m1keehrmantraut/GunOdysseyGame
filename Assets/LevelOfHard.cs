using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOfHard : MonoBehaviour
{
    private WavesSystem wave;
    private BaseHealth bases;

    [SerializeField] private Money _money;
    
    private void Start()
    {
        wave = GameObject.FindWithTag("Wave").GetComponent<WavesSystem>();
        bases = GameObject.FindWithTag("Player").GetComponent<BaseHealth>();
    }

    public void UpgradeEnemyAttack()
    {
        if (wave.currentWave % 2 != 0)
        {
            bases.IncreaseDamage(5);
            Debug.Log("YEEEEEEEEEE");
        }
    }
    
    public void IncreaseMoney()
    {
        if (wave.currentWave % 2 != 0)
        {
            _money.UpgradeBoost(50);
            Debug.Log("Yuuuuu");
        }
    }
}
