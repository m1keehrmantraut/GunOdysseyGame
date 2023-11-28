using System;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable] 
public struct Gunns
{
    public GameObject[] pushka;
    public GameObject[] platform;
    public bool isGun;
    public bool isFirst;
    public int level;
    public string mode;
    public int differ;
}

public class Upgrading : MonoBehaviour
{
    [SerializeField] private Gunns[] Guns;
    [SerializeField] private Image[] LevelCells;
    [SerializeField] private Sprite upgradedCell;
    
    private Shop shop;

    private void Start()
    {
        shop = GameObject.FindWithTag("Shop").GetComponent<Shop>();
    }

    public void Upgrade(int id)
    {
        Gunns temp = Guns[id];
        if (temp.level < 3)
        {
            if (temp.isGun && temp.isFirst)
            {
                temp.platform[0].SetActive(true);
                temp.platform[1].SetActive(true);
                Guns[id].isFirst = false;
            }
            else
            {
                if (temp.mode == "Gun")
                {
                    temp.pushka[0].GetComponent<Shooting>().UpgradeDamage();
                    temp.pushka[1].GetComponent<Shooting>().UpgradeDamage();
                }

                if (temp.mode == "Laser")
                {
                    temp.pushka[0].GetComponent<Laser>().UpgradeLaser(0.2f);
                    temp.pushka[1].GetComponent<Laser>().UpgradeLaser(0.2f);
                }

                if (temp.mode == "HomingGun")
                {
                    temp.pushka[0].GetComponent<HomingShooting>().DecreaseTime();
                    temp.pushka[1].GetComponent<HomingShooting>().DecreaseTime();
                }
            }

            LevelCells[temp.level + temp.differ].sprite = upgradedCell;
            Guns[id].level++;
        }
        else if (temp.level >= 3)
        {
            shop.ChangeMode(id);
        }
    }

    // public void UpgradeGun(int id)
    // {
    //     Guns[id].
    // }
}
