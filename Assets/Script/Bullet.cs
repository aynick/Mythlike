using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    public float Damage = 5;
    [SerializeField] private float _lifeTime;
    private PlayerEventHandler _playerEventHandler;

    private void OnEnable()
    {
    }

    private void Update()
    {
        transform.Translate(Vector2.right * (_speed * Time.deltaTime));
        _lifeTime -= Time.deltaTime;
        if (_lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out EnemyBehavior enemy))
        {
            enemy.EnemyApplyDamage.Apply((int)Damage);
            Debug.Log("POPAL");
        }
    }
}
