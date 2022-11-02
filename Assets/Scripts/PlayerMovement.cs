using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Base Settings")]
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float  _gravityMultiplier = 1;
    
    
    [Header("Grounded")]
    [SerializeField] private Transform _checkGroundTransform;
    [SerializeField] private float _checkGroundRadius;
    [SerializeField] private LayerMask _checkGroundLayer;
    
    
    private void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 moveVector = transform.right * horizontal + transform.forward * vertical;
        moveVector *= _speed * Time.deltaTime;

        _controller.Move(moveVector);

        bool isGrounded = Physics.CheckSphere(_checkGroundTransform.position, _checkGroundRadius, _checkGroundLayer);

        Vector3 fallVector = Vector3.zero;
        float gravity = Physics.gravity.y * _gravityMultiplier;
        fallVector.y += gravity * Time.deltaTime;

        _controller.Move(fallVector);
    }
}
