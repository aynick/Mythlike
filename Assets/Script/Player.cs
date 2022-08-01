using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public abstract class Player : MonoBehaviour
    {
        public int healthPoint;
        public float damage;
        public int protection; 
        public float speed;
        public abstract void InitStats();
    }
}
