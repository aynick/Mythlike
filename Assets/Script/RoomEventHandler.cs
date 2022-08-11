using System;
using UnityEngine;

namespace Script
{
    public class RoomEventHandler : MonoBehaviour
    {
        public event Action OnEnemyDead;
        public event Action OnRoomCleared;

        public void OnEnemyDeath()
        {
            OnEnemyDead?.Invoke();
        }

        public void OnRoomClear()
        {
            OnRoomCleared?.Invoke();
        }
    }
}