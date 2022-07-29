using System;
using UnityEngine;

namespace Script
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Player : MonoBehaviour
    {
        [SerializeField]protected int healthPoint;
        [SerializeField]public int damage;
        [SerializeField]protected int protection;
        [SerializeField] protected float speed;
        private BasePlayerMove _playerMove;
        private BasePlayerAttack _playerAttack;

        private void Awake()
        {
            _playerMove = new BasePlayerMove(GetComponent<Rigidbody2D>(),speed);
            _playerAttack = new BasePlayerAttack(transform,this);
        }

        private void FixedUpdate()
        {
            _playerAttack.Update();
            _playerMove.Update();
        }
    }
}
