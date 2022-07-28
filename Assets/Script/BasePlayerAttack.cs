using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform _hand;
    private Weapon _weapon;
    private Player _playerClass;

    private void Start()
    {
        _weapon = transform.GetChild(0).GetChild(0).GetComponent<Weapon>();
        _playerClass = GetComponent<Player>();
        _weapon.Damage += _playerClass._damage;
    }

    private void Update()
    {
        RotateWeapon();
        Attack();
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _weapon.Attack();
        }
    }
    void RotateWeapon()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var mouseDir = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        var thisVector = transform.right;
        var angle = Vector3.SignedAngle(thisVector, mouseDir, Vector3.forward);
        _hand.localRotation = Quaternion.Euler(transform.localRotation.x,transform.localRotation.y,angle);
        Debug.Log(_hand.localRotation.z);
    }
}
