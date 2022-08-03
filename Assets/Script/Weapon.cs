using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] public float Damage;
    [SerializeField] protected float FireRate;
    protected bool isReady;
    public abstract void Attack();
}
