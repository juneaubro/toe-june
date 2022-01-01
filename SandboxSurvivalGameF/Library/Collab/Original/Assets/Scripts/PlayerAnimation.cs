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
        float speedX = rb.velocity.x;
        float speedZ = rb.velocity.z;

        //animator.SetFloat("speed", );
        //print();
    }
}
