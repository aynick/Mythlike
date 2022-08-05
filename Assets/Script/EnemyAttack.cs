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
        public bool IsAttacked;
        public EnemyAttack(Enemy enemy,Transform transform)
        {
            _transform = transform;
            _damage = enemy.Damage;
            _attackRange = enemy.AttackRange;
            _attackRate = enemy.AttackRate;
            _nextAttack = _attackRate;
        }

        public void Update()
        {
            Debug.LogError(_nextAttack);
            _nextAttack -= Time.deltaTime;
            IsAttacked = false;
            if (_nextAttack < 0)
            {
                IsAttacked = true;
                Player().PlayerApplyDamage.ApplyDamage(_damage);
                _nextAttack = _attackRate;
            }
        }

        public PlayerBehavior Player()
        {
            var colliders = Physics2D.OverlapCircleAll(_transform.position, _attackRange);
            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent(out PlayerBehavior playerBehavior))
                {
                    return playerBehavior;
                }
            }
            return null;
        }
    }
}