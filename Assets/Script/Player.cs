
using System;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    [SerializeField]protected int _healthPoint;
    [SerializeField]public int _damage;
    [SerializeField]protected int _protection;
}
