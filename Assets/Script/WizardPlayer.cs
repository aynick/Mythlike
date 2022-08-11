using System;

namespace Script
{
    public class WizardPlayer : Player
    {
        public override void InitStats()
        {
            speed = 4;
            healthPoint = 2;
            protection = 0;
            damage = 15;
        }
    }
}