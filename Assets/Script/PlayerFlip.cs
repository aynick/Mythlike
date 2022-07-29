using System;
using UnityEngine;

namespace Script
{
    public class PlayerFlip : MonoBehaviour
    {
        [Header("Object is must have Sprite Renderer")]
        [SerializeField]private Transform hand;
        [SerializeField]private Transform leftPos; 
        [SerializeField]private Transform rightPos;
        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _rigidbody2D;

        private void Start()
        {
            _rigidbody2D = gameObject?.GetComponent<Rigidbody2D>();
            _spriteRenderer = gameObject?.GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            FlipHand(_rigidbody2D.velocity.x);
        }

        private void FlipHand(float dir)
        {
            Mathf.Clamp(dir, -1, 1);
            if (dir < 0)
            {
                hand.SetParent(leftPos);
                _spriteRenderer.flipX = true;
            }
            if (dir > 0)
            {
                hand.SetParent(rightPos);
                _spriteRenderer.flipX = false;
            }
            hand.localPosition = Vector3.zero;
        }
    }
}