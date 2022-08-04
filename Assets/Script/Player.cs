using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public abstract class Player
    {
        public int healthPoint;
        public float damage;
        public int protection; 
        public float speed;
        public abstract void InitStats();
    }
}
