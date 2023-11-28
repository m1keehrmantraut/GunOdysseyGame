using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerFollowing : MonoBehaviour
{
    [SerializeField] private float offset;
    [SerializeField] private float angle;
    [SerializeField] private bool isFlipped;
    [SerializeField] private float differAngle;
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
    
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        if ((rotZ < angle || rotZ > angle + differAngle) && isFlipped)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);    
        }
        if ((rotZ > angle || rotZ < angle - differAngle) && !isFlipped)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);    
        }
        
    }
    
    
}