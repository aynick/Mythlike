using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class EnemyPatrol
    {
        private List<Vector2> _directions;
        private int _randomIndex;
        private float _moveRate = 0.5f;
        private float _timer;
        private Rigidbody2D _rigidbody2D;
        private float _speed;
        private Enemy _enemy;
        float rand =10;
        public EnemyPatrol(Rigidbody2D rigidbody2D,Enemy enemy)
        {
            _rigidbody2D = rigidbody2D;
            _speed = enemy.Speed;
            _enemy = enemy;
            InitDirections();
        }

        private void InitDirections()
        {
            _directions = new List<Vector2>
            {
                new Vector2(1, 1),
                new Vector2(1, 0),
                new Vector2(1, -1),
                new Vector2(0, -1),
                new Vector2(0, 1),
                new Vector2(0, 0),
                new Vector2(-1, 0),
                new Vector2(-1, 1),
                new Vector2(-1, -1)
            };
        }

        public void Update()
        {
            var targetDir = _directions[_randomIndex];
            _timer -= Time.deltaTime;
            Debug.LogWarning(rand);
            if (rand < 7)
            {
                targetDir = Vector2.zero;
            }
            Debug.LogWarning(_directions[_randomIndex]);
            _rigidbody2D.velocity =targetDir * _speed;
            if (_timer < 0)
            {
                _randomIndex = Random.Range(0, _directions.Count);
                rand = Random.Range(0, 10);
                _timer = _moveRate;
            }
        }
        public bool FindPlayer()
        {
            foreach (var collider in Physics2D.OverlapCircleAll(_rigidbody2D.gameObject.transform.position,_enemy.DetectRange))
            {
                if (collider.TryGetComponent(out PlayerBehavior player))
                {
                    return true;
                }
            }
            return false;
        }
    }
}