using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
public class StartPlayer : Player
{
    public Weapon TargetWeapon;
    [SerializeField] private Transform _handTransform;
    private Vector2 mousePosition;
    private Camera camera;

    private void Start()
    {
        camera = Camera.main;
    }
    private void Update()
    {
        Move();
        RotateWeapon();
        Attack();
    }

    protected override void Move()
    {
        base.Move();
    }

    protected override void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TargetWeapon.Attack();
        }
    }

    void RotateWeapon()
    {
        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        var mouseDir = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        var thisVector = transform.right;
        var angle = Vector3.SignedAngle(thisVector, mouseDir, Vector3.forward);
        _handTransform.localRotation = Quaternion.Euler(transform.localRotation.x,transform.localRotation.y,angle);
    }
}
