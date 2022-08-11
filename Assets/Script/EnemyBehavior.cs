using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Serialization;
using Script;
using UnityEngine;
using Object = UnityEngine.Object;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class EnemyBehavior : MonoBehaviour,IStateSwitcher
{
    private RoomEventHandler _roomEventHandler;
    private EnemyChase _enemyChase;
    public EnemyApplyDamage EnemyApplyDamage;
    private EnemyPatrol _enemyPatrol;
    private EnemyAttack _enemyAttack;
    private BaseState _currentState;
    private List<BaseState> _allStates;
    private Enemy _enemy;
    public bool isActive;

    [SerializeField] private EnemyType enemyType;

    private void OnEnable()
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
        var rigidbody2D = GetComponent<Rigidbody2D>();
        _roomEventHandler = transform.parent?.GetComponent<RoomEventHandler>();
        EnemyApplyDamage = new EnemyApplyDamage(_enemy,gameObject,_roomEventHandler);
        _enemyChase = new EnemyChase(transform,_enemy,rigidbody2D);
        _enemyPatrol = new EnemyPatrol(rigidbody2D,_enemy);
        _enemyAttack = new EnemyAttack(_enemy,transform);
    }

    private void InitStates()
    {
        var animator = GetComponent<Animator>();
        var rigidbody2D = GetComponent<Rigidbody2D>();
        _allStates = new List<BaseState>()
        {
            new EnemyPatrolState(this,_enemyPatrol,animator,rigidbody2D),
            new EnemyChaseState(this,_enemyChase,_enemy,animator),
            new EnemyAttackState(this,_enemyAttack,_enemy,animator,rigidbody2D),
        };
        _currentState = _allStates[0];
    }

    private void InitType()
    {
        switch (enemyType)
        {
            case EnemyType.Mimik : _enemy = new MimikEnemy(3,2,1,2,10,8);
                break;
            case EnemyType.Troll : _enemy = new TrollEnemy(3,2,1,2,10,8);
                break;
            case EnemyType.Skeleton : _enemy = new SkeletonEnemy(3,2,1,2,10,8);
                break;
            case EnemyType.Slime : _enemy = new SlimeEnemy(3,2,1,2,10,8);
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
        if (isActive)
            _currentState.Action();
        else
            Destroy(gameObject);
    }
}
