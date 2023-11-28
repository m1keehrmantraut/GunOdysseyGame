using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMovement : MonoBehaviour
{
    private Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _animator.SetBool("Prilet", false);
    }

    public void Prilet()
    {
        _animator.SetBool("Prilet", true);
        _animator.SetBool("Otlet", false);
        _animator.SetBool("isIdle", false);
    }

    public void Otlet()
    {
        _animator.SetBool("Prilet", false);
        _animator.SetBool("Otlet", true);
    }

    public void isNotIdle()
    {
        _animator.SetBool("Otlet", false);
        _animator.SetBool("isIdle", true);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
