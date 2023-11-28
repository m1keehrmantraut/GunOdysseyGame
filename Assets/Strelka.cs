using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strelka : MonoBehaviour
{
    [SerializeField] private GameObject str;
    
    private bool isFirst = true;
    public void Disactive()
    {
        str.SetActive(false);
    }

    public void EnableStrelka()
    {
        if (isFirst)
        {
            str.SetActive(true);
            isFirst = false;
        }
    }
}
