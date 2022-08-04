using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Script;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBehavior : MonoBehaviour,IStateSwitcher
{
    private EnemyChase _enemyChase;
    private EnemyPatrol _enemyPatrol;
    private EnemyAttack _enemyAttack;
    private BaseState _currentState;
    private List<BaseState> _allStates;
    private Enemy _enemy;

    [SerializeField] private EnemyType enemyType;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        InitType();
        InitTools();
        InitStates();
    }

    private void InitTools()
    {
        var rigidbody2D = gameObject?.GetComponent<Rigidbody2D>();
        _enemyChase = new EnemyChase(transform,_enemy,rigidbody2D);
        _enemyPatrol = new EnemyPatrol(rigidbody2D,_enemy);
        _enemyAttack = new EnemyAttack(_enemy,transform);
    }

    private void InitStates()
    {
        _allStates = new List<BaseState>()
        {
            new EnemyAttackState(this,_enemyAttack,_enemy),
            new EnemyChaseState(this,_enemyChase,_enemy),
            new EnemyPatrolState(this,_enemyPatrol)
        };
        _currentState = _allStates[0];
    }

    private void InitType()
    {
        switch (enemyType)
        {
            case EnemyType.Mimik : _enemy = new MimikEnemy(3,2,1,5,3,5);
                break;
            case EnemyType.Troll : _enemy = new TrollEnemy(3,2,1,5,3,5);
                break;
            case EnemyType.Skeleton : _enemy = new SkeletonEnemy(3,2,1,5,3,5);
                break;
            case EnemyType.Slime : _enemy = new SlimeEnemy(3,2,1,5,3,5);
                break;
        }
    }
    
    public void SwitchState<T>() where T : BaseState
    {
        var state = _allStates.FirstOrDefault(s => s is T);
        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    private void Update()
    {
        _currentState.Action();
    }
}
