using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    public float Damage = 5;
    [SerializeField] private float _lifeTime;
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
            Debug.Log("Popal");
        }
    }
}
