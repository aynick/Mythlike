using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class EnemyChase
    {
        private readonly Rigidbody2D _rigidbody2D;
        private readonly float _speed;
        public readonly Transform _transform;
        private readonly float _detectRadius;

        public EnemyChase(Transform transform, Enemy enemy, Rigidbody2D rigidbody2D)
        {
            _transform = transform;
            _speed = enemy.Speed;
            _rigidbody2D = rigidbody2D;
            _detectRadius = enemy.DetectRange;
        }

        protected virtual void Move()
        {
            if (FindPlayer() != null)
            {
                if ((Vector2.Distance(_transform.position, FindPlayer().transform.position) <= 3))
                {
                    _rigidbody2D.velocity = Vector2.zero;
                    return;
                }
                var dir = FindPlayer().transform.position - _transform.position;
                _rigidbody2D.velocity = dir.normalized * _speed;
                return;
            }
        }
        
        
        public PlayerBehavior FindPlayer()
        {
            foreach (var collider in DetectColliders())
            {
                if (collider.TryGetComponent(out PlayerBehavior player))
                {
                    return player;
                }
            }
            return null;
        }
        public void Update()
        {
            Move();
        }

        private Collider2D[] DetectColliders()
        {  
            var DetectedColliders = Physics2D.OverlapCircleAll(_transform.position,_detectRadius);
            return DetectedColliders;
        }
    
    }
}