using UnityEngine;

public class BikeController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 0.5f;

    private Rigidbody2D rb;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Horizontal movement
        float moveX = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            moveX = -moveSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveX = moveSpeed;
        }

        rb.velocity = new Vector2(moveX, rb.velocity.y);

        // Jumping
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    // Check if the bike is on the ground
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts.Length > 0 && collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}

