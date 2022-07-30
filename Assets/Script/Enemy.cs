using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int HealthPoint;
    [SerializeField] protected int Damage;
    [SerializeField] protected int Protection;
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _patrolPointsTransform;
    [SerializeField] private float AttackRate;
    [SerializeField] private float _detectRadius;

    private BaseEnemyLogic _baseEnemyLogic;

    private void Start()
    {
        _baseEnemyLogic = new BaseEnemyLogic(_patrolPointsTransform,transform,_speed,gameObject?.GetComponent<Rigidbody2D>(),_detectRadius,AttackRate);
    }

    private void Update()
    {
        _baseEnemyLogic.Update();
    }
    // [SerializeField] protected float Speed;
    // [SerializeField] protected float DetectRadius;
    // [SerializeField] protected float AttackDistace;
    // [SerializeField] protected float AttackRate = 2f; 
    // protected float nextAttack;
    // protected Rigidbody2D rigidbody2D;
    // protected Vector3 targetPos;
    //
    // private void Awake()
    // {
    //     rigidbody2D = GetComponent<Rigidbody2D>();
    // }
    //
    // protected abstract void Move();
    //
    // protected virtual Player FindPlayer()
    // {
    //     foreach (var collider in DetectColliders())
    //     {
    //         if (collider.TryGetComponent(out Player player))
    //         {
    //             return player;
    //         }
    //     }
    //     return null;
    // }
    //
    // protected abstract void Attack(Player player);
    //
    // public void GetDamage(int damage)
    // {
    //     HealthPoint -= damage;
    // }
    //

}
