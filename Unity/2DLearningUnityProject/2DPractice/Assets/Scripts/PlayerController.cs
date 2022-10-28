using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject groundCheck;

    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float jumpForce = 5f;

    private bool isGrounded;

    private Rigidbody2D rb;
    private Animator ani;
    private Vector2 movement;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = rb.velocity.y;

        ani.SetFloat("xSpeed", movement.x * movement.x); // sqr will never be negative
        ani.SetFloat("ySpeed", movement.y);

        if (movement.y == 0)
            ani.SetBool("onGround", true);
        else
            ani.SetBool("onGround", false);

        if (rb.velocity.x > 0.01f)
            Flip(1);

        if (rb.velocity.x < -0.01f)
            Flip(-1);

        Jump();

    }

    private void FixedUpdate()
    {
        MoveChar();
    }

    void Flip(float direction)
    {
        Vector3 flip = new Vector3(direction, transform.localScale.y, transform.localScale.z);

        transform.localScale = flip;
    }

    void MoveChar()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded == true)
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
            isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
            isGrounded = false;
    }
}
