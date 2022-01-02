using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour{
    private Rigidbody rb;
    private CharacterController cc;
    private float speed = 0.1f;
    private float yVel = 0f;
    private float gravity;
    private float gravityMultiplier = 0.01f;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
        gravity = Physics.gravity.y;
    }

    private void FixedUpdate() {
        Move();
    }

    private void Move() {
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal") * speed, 
            yVel, 
            Input.GetAxisRaw("Vertical") * speed);
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.z;
        if (cc.isGrounded && gravity < 0)
            yVel = 0f;
        yVel += -(gravityMultiplier);
        move.y = yVel;
        cc.Move(move);
    }
}
