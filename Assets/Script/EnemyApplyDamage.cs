using UnityEngine;

namespace Script
{
    public class EnemyApplyDamage
    {
        private int healthPoint;
        private GameObject _gameObject;
        private RoomEventHandler _roomEventHandler;

        public EnemyApplyDamage(Enemy enemy,GameObject gameObject,RoomEventHandler roomEventHandler)
        {
            healthPoint = enemy._healthPoint;
            _gameObject = gameObject;
            _roomEventHandler = roomEventHandler;
        }
        
        public void Apply(int damage)
        {
            healthPoint -= damage;
            if (healthPoint <= 0)
            {
                _roomEventHandler.OnEnemyDeath();
                Object.Destroy(_gameObject);
            }
        }
    }
}