using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Script;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Transform _playerTransform;
    private CinemachineVirtualCamera _cinemachineCamera;

    private void Awake()
    {
        _cinemachineCamera = GetComponent<CinemachineVirtualCamera>();
        _playerTransform = FindObjectOfType<PlayerBehavior>().transform;
        _cinemachineCamera.Follow = _playerTransform;
        _cinemachineCamera.LookAt = _playerTransform;
    }
}
