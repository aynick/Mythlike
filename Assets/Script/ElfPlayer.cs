﻿namespace Script
{
    public class ElfPlayer : Player
    {
        public override void InitStats()
        {
            speed = 25f;
            healthPoint = 2;
            protection = 1;
            damage = 1.5f;
        }
    }
}