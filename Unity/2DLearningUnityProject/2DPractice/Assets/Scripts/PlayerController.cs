using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float jumpForce = 5f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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
        // rb move pos
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            // addforce impulse
        }
    }
}
