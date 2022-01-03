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
    private Vector3 gravity;
    private bool jump = false;
    public bool grounded;
    public float gravityMultiplier = 1f;
    public float jumpForce = 7f;
    public float walkSpeed = 0.1f;

    private void Start() {
        rb = GetComponent<Rigidbody>();
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
            gravity = new Vector3(
                0,
                -(Mathf.Abs(Mathf.Pow(Physics.gravity.y, 2f) * gravityMultiplier)),
                0);

            rb.AddForce(gravity);
        }
    }

    private void Jump() {
        rb.velocity = new Vector3(mov.x,1,mov.z) * jumpForce;
        jump = false;
    }
}
