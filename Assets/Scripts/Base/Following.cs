using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following : MonoBehaviour
{
    [SerializeField] private float offset;
    [SerializeField] private float initialRotation;
    [SerializeField] private float angle;
    [SerializeField] private bool isFlipped;

    [SerializeField] private Sprite activeGun;

    private Sprite defaultSprite;
    private SpriteRenderer _spriteRenderer;
    
    private void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        defaultSprite = _spriteRenderer.sprite;
    }

    private void Follow()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
    
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if (!isFlipped && (rotZ > initialRotation - angle && rotZ < initialRotation + angle))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);    
        }
        if (isFlipped && (rotZ < initialRotation - angle || rotZ > initialRotation + angle))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);    
        }

    }

    
    public void ChangeMode(bool isActive)
    {
        if (isActive)
        {
            InvokeRepeating(nameof(Follow), 0f, Time.deltaTime);
            _spriteRenderer.sprite = activeGun;
        }
        else
        {
            CancelInvoke(nameof(Follow));
            _spriteRenderer.sprite = defaultSprite;
        }
    }
}