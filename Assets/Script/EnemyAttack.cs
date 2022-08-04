using UnityEngine;

namespace Script
{
    public class EnemyAttack
    {
        private float _attackRate;
        private float _nextAttack;
        private int _damage;
        private float _attackRange;
        public Transform _transform;
        public EnemyAttack(Enemy enemy,Transform transform)
        {
            _transform = transform;
            _damage = enemy.Damage;
            _attackRange = enemy.AttackRange;
            _attackRate = enemy.AttackRate;
            _nextAttack = _attackRange;
        }

        public void Update()
        {
            _nextAttack -= Time.deltaTime;
            if (_nextAttack < 0)
            {
                Player().PlayerApplyDamage.ApplyDamage(_damage);
                _nextAttack = _attackRange;
            }
        }

        public PlayerBehavior Player()
        {
            var collider = Physics2D.OverlapCircle(_transform.position, _attackRange);
            if (collider.TryGetComponent(out PlayerBehavior playerBehavior))
            {
                return playerBehavior;
            }

            return null;
        }
    }
}