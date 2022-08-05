using System;
using UnityEngine;

namespace Script
{
    public class EnemyFlip : MonoBehaviour
    {
        [Header("Object is must have Sprite Renderer")]
        private Rigidbody2D _rigidbody2D;

        private float _leftScale;

        private void Start()
        {
            _rigidbody2D = gameObject?.GetComponent<Rigidbody2D>();
            _leftScale = -transform.localScale.x;
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
                transform.localScale = new Vector3(_leftScale, 1, 1);
            }
            if (dir > 0)
            {
                transform.localScale = new Vector3(-_leftScale, 1, 1);
            }
        }
    }
}