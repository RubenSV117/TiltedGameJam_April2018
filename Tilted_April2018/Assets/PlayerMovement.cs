﻿using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _characterController;
    private Animator _animator;

    [SerializeField]
    private float _moveSpeed = 150;
    [SerializeField]
    private float _turnSpeed = 5f;
    [SerializeField]
    private float _jumpStrength;

    [SerializeField] private CinemachineVirtualCamera _vcam;

    private Vector3 _lookDirection;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponentInChildren<Animator>();
       
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var movement = new Vector3(horizontal, 0, vertical);

        _lookDirection = transform.position - _vcam.transform.position;

        if(vertical > 0)
        _characterController.SimpleMove(Vector3.Normalize(Camera.main.transform.forward
                                        ) * Time.deltaTime * _moveSpeed);

        else if (vertical < 0)
            _characterController.SimpleMove(-Vector3.Normalize(Camera.main.transform.forward
                                            ) * Time.deltaTime * _moveSpeed);


        _animator.SetFloat("Speed", movement.magnitude);

        if (movement.magnitude > 0)
        {
            //Quaternion newDirection = Quaternion.LookRotation(movement);

            //transform.rotation = Quaternion.Slerp(transform.rotation, newDirection, Time.deltaTime * _turnSpeed);
            transform.forward = Camera.main.transform.forward;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        }

        if (_characterController.isGrounded && Input.GetButton("Jump"))
            _characterController.Move(Vector3.up * Time.deltaTime * _jumpStrength);
    }
}
