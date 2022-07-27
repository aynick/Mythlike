
using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public abstract class Player : MonoBehaviour
{
    [SerializeField] protected int Damage;
    [SerializeField] protected int HealthPoint;
    [SerializeField] protected int Speed;
    protected Rigidbody2D rigidbody2D;
    [SerializeField]
    protected Joystick Joystick;
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    protected virtual void Move()
    {
         if (Joystick.Horizontal == 0 || Joystick.Vertical == 0 && rigidbody2D.velocity != Vector2.zero) rigidbody2D.velocity = Vector2.zero;
         var targetPos = new Vector2(Joystick.Horizontal * Speed, Joystick.Vertical * Speed);
         rigidbody2D.velocity = targetPos;
    }
    protected abstract void Attack();

    public virtual void GetDamage(int damage)
    {
        HealthPoint -= damage;
        if (HealthPoint <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
