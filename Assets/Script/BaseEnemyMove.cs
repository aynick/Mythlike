using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class BaseEnemyLogic
    {
        private Rigidbody2D _rigidbody2D;
        private float _speed;
        private List<Vector3> _patrolPointsPos = new List<Vector3>();
        private Transform _transform;
        
        private float nextAttack;
        private float AttackRate;
        private GameObject thisGameObject;
        private float _detectRadius;
        private int _randomIndex;

        public BaseEnemyLogic(Transform transform,float speed,Rigidbody2D rigidbody2D,float detectRadius,float attackRate)
        {
            _transform = transform;
            _speed = speed;
            _rigidbody2D = rigidbody2D;
            _detectRadius = detectRadius;
            thisGameObject = rigidbody2D.gameObject;
            AttackRate = attackRate;
        }

        public BaseEnemyLogic(Transform[] patrolPoints, Transform transform, float speed, Rigidbody2D rigidbody2D,float detectRadius,float attackRate) : this(transform,speed,rigidbody2D,detectRadius,attackRate)
        {
            foreach (var point in patrolPoints)
            {
                _patrolPointsPos.Add(point.position);
            }
            
        }

        protected virtual void Move()
        {
            if (FindPlayer() != null)
            {
                _rigidbody2D.MovePosition(Vector2.MoveTowards(_transform.position ,FindPlayer().transform.position, _speed));
                if ((Vector2.Distance(_transform.position, FindPlayer().transform.position) <= 1))
                {
                    Attack(FindPlayer());
                }
                return;
            }
            if (_transform.position == _patrolPointsPos[_randomIndex])
            {
                _randomIndex = Random.Range(0, _patrolPointsPos.Count);
            }
            else
            {
                _rigidbody2D.MovePosition(Vector2.MoveTowards(_transform.position ,_patrolPointsPos[_randomIndex], _speed));
            }
        }
        
        protected virtual Player FindPlayer()
        {
            foreach (var collider in DetectColliders())
            {
                if (collider.TryGetComponent(out Player player))
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

        private void DestroyGameObject(GameObject gameObject)
        {
            gameObject.SetActive(false);
        }

        private Collider2D[] DetectColliders()
        {  
            var DetectedColliders = Physics2D.OverlapCircleAll(_transform.position,_detectRadius);
            return DetectedColliders;
        }
    
        protected virtual void Attack(Player player)
        {
            if (Time.time > nextAttack)
            {
                nextAttack = AttackRate;
                // player.GetDamage(Damage);
            }
        }
    }
}