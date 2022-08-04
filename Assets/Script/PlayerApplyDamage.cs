using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Script
{
    public class PlayerApplyDamage
    {
        private Player _player;
        public PlayerApplyDamage(Player player)
        {
            _player = player;
        }
        public void ApplyDamage(int damage)
        {
            if (_player.healthPoint - damage <= 0) 
                Debug.Log("Dead");
            else
                _player.healthPoint -= damage;
        }
    }
}