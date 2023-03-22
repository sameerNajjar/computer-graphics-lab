using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class Player : MonoBehaviour {
    [SerializeField] private float movSpd = 2.0f;
    [SerializeField] private InputControl inputControl;
    [SerializeField] private bool onGround;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float jumpHeight = 3.0f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private CharacterController controller;
    [SerializeField] Vector3 velocity=Vector3.zero;
    void Start() {
        controller= GetComponent<CharacterController>();
        inputControl.onJumpPressed += onJump;
    }


    void Update() {
        onGround = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);
        Vector2 input = inputControl.getPlayerMovVec2Norm();
        Vector3 movDirection = transform.right*input.x+transform.forward*input.y;
        controller.Move(movDirection * movSpd * Time.deltaTime);
        if (onGround&& velocity.y<0) {
            velocity.y = -2f;
        }
        else {
            velocity.y += gravity * Time.deltaTime;
        }
        controller.Move(velocity * Time.deltaTime);
    }
    public void onJump(object obj, EventArgs e) {
        if (onGround) {
            velocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }
    }
}
