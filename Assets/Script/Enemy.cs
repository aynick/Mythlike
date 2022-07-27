using System;
using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int HealthPoint;
    [SerializeField] protected int Damage;
    [SerializeField] protected float Speed;
    [SerializeField] protected float DetectRadius;
    [SerializeField] protected float AttackDistace;
    [SerializeField] protected float AttackRate = 2f; 
    protected float nextAttack;
    protected Rigidbody2D rigidbody2D;
    protected Vector3 targetPos;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    protected abstract void Move();

    protected virtual Player FindPlayer()
    {
        foreach (var collider in DetectColliders())
        {
            if (collider.TryGetComponent(out Player player))
            {
                return player;
            }
        }
        return null;
    }

    protected abstract void Attack(Player player);

    public void GetDamage(int damage)
    {
        HealthPoint -= damage;
    }

    private Collider2D[] DetectColliders()
    {  
        var DetectedColliders = Physics2D.OverlapCircleAll(transform.position,DetectRadius);
        return DetectedColliders;
    }
}
