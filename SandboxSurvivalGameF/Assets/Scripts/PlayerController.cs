using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour
{

    public float walkSpeed = 0.5f;
    public float sprintSpeed = 1.5f;
    public float maxSpeed = 15.0f;
    public float maxVelocityChange = 10.0f;
    public float gravity = 15.0f;
    public bool canJump = true;
    public bool canSprint = true;
    public float jumpHeight = 2.0f;
    private bool grounded = false;
    public static Vector3 targetVelocity;
    public bool b_canAnimate = false;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.useGravity = false;
    }

    void Update()
    {
        if(grounded)
        {
            if (Input.GetButton("Forwards") || Input.GetButton("Backwards") || Input.GetButton("Left") || Input.GetButton("Right"))
            {
                b_canAnimate = true;

                // Calculate how fast we should be moving
                targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                targetVelocity = transform.TransformDirection(targetVelocity);
                targetVelocity = targetVelocity.normalized;
                targetVelocity *= walkSpeed;

                Vector3 velocityChange = (targetVelocity - rb.velocity);
                velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
                velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
                velocityChange.y = 0;

                if (rb.velocity.magnitude < maxVelocityChange)
                    rb.AddForce(velocityChange, ForceMode.VelocityChange);

            } else
            {
                rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, 0.5f);
            }

            // Jump
            if (canJump && Input.GetButton("Jump"))
            {
                rb.velocity = new Vector3(rb.velocity.x, CalculateJumpVerticalSpeed(), rb.velocity.z);
            }

            // Sprint
            //if (canSprint && Input.GetButton("Sprint") && Input.GetButton("Forwards") && (rb.velocity.magnitude < 20f))
            //    rb.

        }

        rb.AddForce(new Vector3(0, -gravity * rb.mass, 0));

        grounded = false;
    }

    void OnCollisionStay()
    {
        grounded = true;
    }

    float CalculateJumpVerticalSpeed()
    {
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }
}
