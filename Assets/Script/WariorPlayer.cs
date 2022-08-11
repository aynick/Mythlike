using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using Unity.Mathematics;
using UnityEngine;
public class WarriorPlayer : Player
{
    public override void InitStats()
    {
        healthPoint = 5;
        protection = 3;
        damage = 1;
        speed = 12;
    }
}
