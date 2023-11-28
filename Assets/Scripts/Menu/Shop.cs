using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable] 
public struct ShopSlots
{
    public int money;
    public int resources;
    public GameObject Slot;
    public UnityEvent OnBuy;
    public bool isActive;
    public int level;
    public float costModifier;
}

public class Shop : MonoBehaviour
{
    private Money moneky;

    public ShopSlots[] shopik;

    [SerializeField] private TMP_Text[] moneys;
    [SerializeField] private TMP_Text[] resources;

    [SerializeField] private AudioSource _audioSource;
    
    void Start()
    {
        moneky = GameObject.FindWithTag("Player").GetComponent<Money>();
        UpdateCosts();
    }

    
    public void BuyItem(int id)
    {
        var mon = shopik[id].money;
        var res = shopik[id].resources;
        if (mon <= moneky.GetMoneyCount() 
            && res <= moneky.GetResourcesCount() && shopik[id].level < 3)
        {
            shopik[id].OnBuy.Invoke();
            moneky.IncreaseMoney(-mon);
            moneky.IncreaseResources(-res);
            shopik[id].level++;
            _audioSource.Play();
            ChangeCost(id);
        }
    }
    
    public void ChangeMode(int index)
    {
        shopik[index].isActive = false;
    }

    public void ChangeCost(int id)
    {
        if (shopik[id].level < 3)
        {
            shopik[id].money = (int)(shopik[id].money * shopik[id].costModifier);
            shopik[id].resources = (int)(shopik[id].resources * shopik[id].costModifier);
            UpdateCosts();    
        }
        else
        {
            Destroy(moneys[id]);
            Destroy(resources[id]);
        }
    }
    
    
    void UpdateCosts()
    {
        for (int i = 0; i < moneys.Length; i++)
        {
            moneys[i].text = shopik[i].money.ToString();
            resources[i].text = shopik[i].resources.ToString();
        }
    }
}
