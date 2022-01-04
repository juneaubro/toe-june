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
<<<<<<< Updated upstream
    private Vector3 gravity;
    private bool jump = false;
    public bool grounded;
    public float gravityMultiplier = 1f;
    public float jumpForce = 7f;
    public float walkSpeed = 0.1f;
=======
    public static bool jump = false;
    public static bool sprint = false;

    public float SPEED_LIMITER = 0.02f;
    public bool grounded;
    public float gravityMultiplier = 55f;
    public float jumpForce = 25f;
    public float walkSpeed = 23f;
    public float sprintSpeed = 100.5f;
>>>>>>> Stashed changes

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
        if (Input.GetButton("Jump") && grounded)
            jump = true;
        if (Input.GetButton("Sprint") && grounded)
        {
            sprint = true;
        } else
        {
            sprint = false;
        }
    }

    private void Move() {
        if (!sprint)
        {
            input = new Vector3(
                Input.GetAxisRaw("Horizontal") * walkSpeed,
                0,
                Input.GetAxisRaw("Vertical") * walkSpeed);
            //mov = input.x * transform.right + input.z * transform.forward;

            //rb.AddForce(mov);
        } else
        {
            input = new Vector3(
                Input.GetAxisRaw("Horizontal") * sprintSpeed,
                0,
                Input.GetAxisRaw("Vertical") * sprintSpeed);
        }
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
