using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Animate();
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    void Animate() {

        //lmao
        if (movement.x > 0) {                   // moving right
            animator.SetFloat("VelocityX", 1);
        } else if(movement.x < 0) {             // moving left
            animator.SetFloat("VelocityX", -1);
        } else {
            animator.SetFloat("VelocityX", 0);
        }
        
        if(movement.z > 0) {             // moving forward
            animator.SetFloat("VelocityZ", 1);
        } else if(movement.z < 0) {             // moving backward
            animator.SetFloat("VelocityZ", -1);
        } else {
            animator.SetFloat("VelocityZ", 0);
        }

        if(movement.z > 0 && movement.x > 0) { // moving forward right
            animator.SetFloat("VelocityX", 1);
            animator.SetFloat("VelocityZ", 1);
        } else if (movement.z > 0 && movement.x < 0) { // moving forward left
            animator.SetFloat("VelocityX", -1);
            animator.SetFloat("VelocityZ", 1);
        } else if (movement.z < 0 && movement.x < 0) { // moving backward left
            animator.SetFloat("VelocityX", -1);
            animator.SetFloat("VelocityZ", -1);
        } else if (movement.z < 0 && movement.x > 0) { // moving backward right
            animator.SetFloat("VelocityX", 1);
            animator.SetFloat("VelocityZ", -1);
        }
    }
}
