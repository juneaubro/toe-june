using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator animator;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float velocityX = PlayerController.velocityX;
        float velocityZ = PlayerController.velocityZ;
        Vector3 speed = rb.velocity;

        animator.SetFloat("speed", speed.magnitude);
        print(speed.magnitude);
    }
}
