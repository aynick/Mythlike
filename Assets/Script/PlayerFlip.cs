﻿using System;
using UnityEngine;

namespace Script
{
    public class PlayerFlip : MonoBehaviour
    {
        [Header("Object is must have Sprite Renderer")]
        [SerializeField]private Transform hand;
        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _rigidbody2D;
        private SpriteRenderer weaponSprite;

        private void Start()
        {
            _rigidbody2D = gameObject?.GetComponent<Rigidbody2D>();
            _spriteRenderer = gameObject?.GetComponent<SpriteRenderer>(); 
            weaponSprite = hand.Find("StartWeapon").GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            Flip(_rigidbody2D.velocity.x);
        }

        public void Flip(float dir)
        {
            Mathf.Clamp(dir, -1, 1);
            if (dir < 0)
            {
                _spriteRenderer.flipX = true; 
                weaponSprite.flipY = true;
            }
            if (dir > 0)
            { 
                _spriteRenderer.flipX = false; 
                weaponSprite.flipY = false;
            }
        }
    }
}