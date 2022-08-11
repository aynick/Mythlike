using System;
using UnityEngine;

namespace Script
{
    public class Door : MonoBehaviour
    {
        private Room _room;
        public bool isLockable;
        public bool isActive;
        private SpriteRenderer _spriteRenderer;
        private Collider2D _collider2D;
        [SerializeField] private Transform point;

        private void Awake()
        {
            _room = transform.parent.GetComponent<Room>();
            _collider2D = GetComponent<Collider2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Lock(bool islock)
        {
            isActive = true;
            _collider2D.isTrigger = !islock;
            _spriteRenderer.enabled = islock;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerBehavior playerBehavior))
            {
                if (isLockable)
                {
                    _room.Lock(true);
                    playerBehavior.transform.position = point.position;
                }
            }
        }
    }
}