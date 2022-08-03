using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float smooth;
    private float _nearSmooth;
    [SerializeField] private float range;

    private void Awake()
    {
        _nearSmooth = smooth / 5;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Vector2.Distance(transform.position,_playerTransform.position) < range)
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var playerPos = _playerTransform.position;
            var targetPos = mousePos - playerPos;
            targetPos.z = transform.position.z;
            var position = Vector3.LerpUnclamped(transform.position, mousePos, smooth*Time.deltaTime);
            transform.position = position;
        }
        else
        {
            var playerPos = _playerTransform.position;
            playerPos.z = transform.position.z;
            var position = Vector3.LerpUnclamped(transform.position, playerPos, smooth * Time.deltaTime);
            transform.position = position;
        }
    }
}
