using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BasePlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private Rigidbody2D _rigidbody2D;
    private Transform _hand;
    [SerializeField] private Transform _leftPos;
    [SerializeField] private Transform _rightPos;
    [SerializeField]private SpriteRenderer _spriteRenderer;
    

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _hand = transform.Find("Hand");
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        var dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _rigidbody2D.velocity = dir * _speed;
        FlipHand(dir.x);
    }

    private void FlipHand(float dir)
    {
        Mathf.Clamp(dir, -1, 1);
        if (dir < 0)
        {
            _hand.SetParent(_leftPos);
            _spriteRenderer.flipX = true;
        }
        if (dir > 0)
        {
            _hand.SetParent(_rightPos);
            _spriteRenderer.flipX = false;
        }
        _hand.localPosition = Vector3.zero;
    }
}
