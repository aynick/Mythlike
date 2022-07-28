using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class OrcEnemy : Enemy
{
    
    // [SerializeField]private List<Transform> _patrolPointsTransform;
    // private List<Vector3> _patrolPointsPos = new List<Vector3>();
    // private int randomIndex;
    // private void Update()
    // {
    //     Move();
    //     if (HealthPoint <= 0)
    //     {
    //         Destroy(gameObject);
    //     }
    // }
    //
    // private void Start()
    // {
    //     foreach (var pointTransform in _patrolPointsTransform)
    //     {
    //         _patrolPointsPos.Add(pointTransform.position);
    //     }
    // }
    //
    // protected override void Move()
    // {
    //     if (FindPlayer() != null)
    //     {
    //         rigidbody2D.MovePosition(Vector2.MoveTowards(transform.position ,FindPlayer().transform.position, Speed));
    //         if ((Vector2.Distance(transform.position, FindPlayer().transform.position) <= 1))
    //         {
    //             Attack(FindPlayer());
    //         }
    //         return;
    //
    //     }
    //     if (transform.position == _patrolPointsPos[randomIndex])
    //     {
    //         randomIndex = Random.Range(0, _patrolPointsPos.Count);
    //     }
    //     else
    //     {
    //         rigidbody2D.MovePosition(Vector2.MoveTowards(transform.position ,_patrolPointsPos[randomIndex], Speed));
    //     }
    // }
    //
    // protected override void Attack(Player player)
    // {
    //     if (Time.time > nextAttack)
    //     {
    //         nextAttack = Time.time + AttackRate;
    //         player.GetDamage(Damage);
    //     }
    // }
}
