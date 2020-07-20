using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 4.5f;
    public float gravity = -15f;
    public float jumpHeight = 1f;

    public Transform groundCheck;
    public float groundDistance = 0.3f;
    public LayerMask groundMask;
    public float slopeForce = 0f;
    public float slopeForceRayLength = 0f;

    Vector3 velocity;
    bool isGrounded;
    CharacterController cc;

    private void Awake()
    {// dont ask why theres two
        cc = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded == true && velocity.y < 0)
        {
            velocity.y = -0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if ((z != 0 || x != 0) && OnSlope())
            cc.Move(Vector3.down * cc.height / 2 * slopeForce * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private bool OnSlope()
    {
        if (!isGrounded)
            return false;

        RaycastHit hit;
        if(Physics.Raycast(transform.position,Vector3.down,out hit,cc.height / 2 * slopeForceRayLength))
            if (hit.normal != Vector3.up)
                return true;
        return false;
    }
}
