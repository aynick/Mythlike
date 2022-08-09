using UnityEngine;

namespace Script
{
    public class EnemyApplyDamage
    {
        private int healthPoint;
        private GameObject _gameObject;
        private PlayerEventHandler _playerEventHandler;

        public EnemyApplyDamage(Enemy enemy,GameObject gameObject,PlayerEventHandler playerEventHandler)
        {
            healthPoint = enemy._healthPoint;
            _gameObject = gameObject;
        }
        
        public void Apply(int damage)
        {
            healthPoint -= damage;
            if (healthPoint <= 0)
            {
                Object.Destroy(_gameObject);
            }
        }
    }
}