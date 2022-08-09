using System;
using UnityEngine;

namespace Script
{
    public class PlayerEventHandler : MonoBehaviour
    {
        public event Action<int> isAttacked;

        public void Attack(int damage)
        {
            isAttacked?.Invoke(damage);
        }
    }
}