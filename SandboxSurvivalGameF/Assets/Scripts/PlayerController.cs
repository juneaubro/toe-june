using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    private Vector3 input;
    public bool grounded;
    public float jumpForce = 7f;
    public float walkSpeed = 0.1f;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        Move();
        Jump();
    }

    private void Update() {
        grounded = GroundCheck.isGrounded;
    }

    private void Move() {
        input = new Vector3(
            Input.GetAxisRaw("Horizontal") * walkSpeed,
            0,
            Input.GetAxisRaw("Vertical") * walkSpeed);

        transform.Translate(input);
    }

    private void Jump() {
        if(Input.GetKeyDown(KeyCode.Space) && grounded) {
            rb.velocity = Vector3.up * jumpForce;
        }
    }
}
