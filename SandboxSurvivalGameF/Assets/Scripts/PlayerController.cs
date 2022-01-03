using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    private Vector3 input;
    private Vector3 mov;
    private bool jump = false;

    public float SPEED_LIMITER = 0.02f;
    public bool grounded;
    public float gravityMultiplier = 55f;
    public float jumpForce = 25f;
    public float walkSpeed = 23f;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        rb.mass = 1f;
        rb.drag = 4f;
        rb.angularDrag = 2f;
    }

    private void FixedUpdate() {
        Move();
        Gravity();
        if (jump)
            Jump();
    }

    private void Update() {
        grounded = GroundCheck.isGrounded;
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
            jump = true;
    }

    private void Move() {
        input = new Vector3(
            Input.GetAxisRaw("Horizontal") * walkSpeed,
            0,
            Input.GetAxisRaw("Vertical") * walkSpeed);
        mov = input.x * transform.right + input.z * transform.forward;

        rb.AddForce(mov);
    }

    private void Gravity() {
        if (!grounded) {
            rb.AddForce(new Vector3(0, -1, 0) * gravityMultiplier, ForceMode.Force);
        } else {
            rb.AddForce(new Vector3(0, rb.velocity.y * -1, 0));
        }
        // maybe do F = ma later
    }

    private void Jump() {
        rb.AddForce(new Vector3(mov.x * SPEED_LIMITER,
            1,
            mov.z * SPEED_LIMITER) * jumpForce,
            ForceMode.VelocityChange);
        jump = false;
    }
}
