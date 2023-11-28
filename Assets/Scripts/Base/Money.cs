using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Money : MonoBehaviour
{
    private int money = 100;
    private int resources = 100;
    
    [SerializeField] private TMP_Text mon;
    [SerializeField] private TMP_Text res;

    private int boost = 0;

    private void Start()
    {
        UpdateMoney();
        UpdateResources();
    }

    public void IncreaseMoney(int amount)
    {
        money += amount + boost;
        UpdateMoney();
    }

    public void IncreaseResources(int amount)
    {
        resources += amount + boost;
        UpdateResources();
    }

    public int GetMoneyCount()
    {
        return money;
    }

    public int GetResourcesCount()
    {
        return resources;
    }

    public void LootMoney()
    {
        int mon = Random.Range(80, 160);
        IncreaseMoney(mon);
    }

    public void LootResources()
    {
        int res = Random.Range(100, 180);
        IncreaseResources(res);
    }
    
    public void UpdateMoney()
    {
        mon.text = GetMoneyCount().ToString();
    }
    
    public void UpdateResources()
    {
        res.text = GetResourcesCount().ToString();
    }

    public void UpgradeBoost(int amount)
    {
        boost += amount;
    }
}
