using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private Vector3 movement;
    private float animSpeed = 0.05f;
    private float walkingValueMax = 0.4f;
    private float sprintingValueMax = 1.2f;
    private bool sprinting;
    private bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        grounded = GroundCheck.isGrounded;
        animator.SetBool("grounded", grounded);

        if (Input.GetKey(KeyCode.LeftShift))
            SprintAnimations();
        else
            WalkAnimations();

        if (Input.GetButtonDown("Jump") && grounded)
            JumpAnimations();
    }

    void WalkAnimations() {
        //lmao
        if (movement.x > 0) {                   // moving right
            animator.SetFloat("dirz", Mathf.Lerp(animator.GetFloat("dirz"), walkingValueMax, animSpeed));
        } else if(movement.x < 0) {             // moving left
            animator.SetFloat("dirz", Mathf.Lerp(animator.GetFloat("dirz"), -walkingValueMax, animSpeed));
        } else {
            animator.SetFloat("dirz", Mathf.Lerp(animator.GetFloat("dirz"), 0, animSpeed));
        }
        
        if(movement.z > 0) {             // moving forward
            animator.SetFloat("dirx", Mathf.Lerp(animator.GetFloat("dirx"), walkingValueMax, animSpeed));
        } else if(movement.z < 0) {             // moving backward
            animator.SetFloat("dirx", Mathf.Lerp(animator.GetFloat("dirx"), -walkingValueMax, animSpeed));
        } else {
            animator.SetFloat("dirx", Mathf.Lerp(animator.GetFloat("dirx"), 0, animSpeed));
        }

        if(movement.z > 0 && movement.x > 0) { // moving forward right
            animator.SetFloat("dirx", Mathf.Lerp(animator.GetFloat("dirx"), walkingValueMax, animSpeed));
            animator.SetFloat("dirz", Mathf.Lerp(animator.GetFloat("dirz"), walkingValueMax, animSpeed));
        } else if (movement.z > 0 && movement.x < 0) { // moving forward left
            animator.SetFloat("dirx", Mathf.Lerp(animator.GetFloat("dirx"), walkingValueMax, animSpeed));
            animator.SetFloat("dirz", Mathf.Lerp(animator.GetFloat("dirz"), -walkingValueMax, animSpeed));
        } else if (movement.z < 0 && movement.x < 0) { // moving backward left
            animator.SetFloat("dirx", Mathf.Lerp(animator.GetFloat("dirx"), -walkingValueMax, animSpeed));
            animator.SetFloat("dirz", Mathf.Lerp(animator.GetFloat("dirz"), -walkingValueMax, animSpeed));
        } else if (movement.z < 0 && movement.x > 0) { // moving backward right
            animator.SetFloat("dirx", Mathf.Lerp(animator.GetFloat("dirx"), -walkingValueMax, animSpeed));
            animator.SetFloat("dirz", Mathf.Lerp(animator.GetFloat("dirz"), walkingValueMax, animSpeed));
        }
    }

    void SprintAnimations() {
        //lmao
        if (movement.x > 0) {                   // moving right
            animator.SetFloat("dirz", Mathf.Lerp(animator.GetFloat("dirz"), sprintingValueMax, animSpeed));
        } else if (movement.x < 0) {             // moving left
            animator.SetFloat("dirz", Mathf.Lerp(animator.GetFloat("dirz"), -sprintingValueMax, animSpeed));
        } else {
            animator.SetFloat("dirz", Mathf.Lerp(animator.GetFloat("dirz"), 0, animSpeed));
        }

        if (movement.z > 0) {             // moving forward
            animator.SetFloat("dirx", Mathf.Lerp(animator.GetFloat("dirx"), sprintingValueMax, animSpeed));
        } else if (movement.z < 0) {             // moving backward
            animator.SetFloat("dirx", Mathf.Lerp(animator.GetFloat("dirx"), -sprintingValueMax, animSpeed));
        } else {
            animator.SetFloat("dirx", Mathf.Lerp(animator.GetFloat("dirx"), 0, animSpeed));
        }

        if (movement.z > 0 && movement.x > 0) { // moving forward right
            animator.SetFloat("dirx", Mathf.Lerp(animator.GetFloat("dirx"), sprintingValueMax, animSpeed));
            animator.SetFloat("dirz", Mathf.Lerp(animator.GetFloat("dirz"), sprintingValueMax, animSpeed));
        } else if (movement.z > 0 && movement.x < 0) { // moving forward left
            animator.SetFloat("dirx", Mathf.Lerp(animator.GetFloat("dirx"), sprintingValueMax, animSpeed));
            animator.SetFloat("dirz", Mathf.Lerp(animator.GetFloat("dirz"), -sprintingValueMax, animSpeed));
        } else if (movement.z < 0 && movement.x < 0) { // moving backward left
            animator.SetFloat("dirx", Mathf.Lerp(animator.GetFloat("dirx"), -sprintingValueMax, animSpeed));
            animator.SetFloat("dirz", Mathf.Lerp(animator.GetFloat("dirz"), -sprintingValueMax, animSpeed));
        } else if (movement.z < 0 && movement.x > 0) { // moving backward right
            animator.SetFloat("dirx", Mathf.Lerp(animator.GetFloat("dirx"), -sprintingValueMax, animSpeed));
            animator.SetFloat("dirz", Mathf.Lerp(animator.GetFloat("dirz"), sprintingValueMax, animSpeed));
        }
    }

    void JumpAnimations() {
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Jump") || !animator.GetCurrentAnimatorStateInfo(0).IsName("Air") || !animator.GetCurrentAnimatorStateInfo(0).IsName("Land"))
            animator.SetTrigger("jump");
    }
}
