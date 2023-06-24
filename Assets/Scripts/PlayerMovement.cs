using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 7f;
    [SerializeField] private float jumpForce = 1200f;                          // Amount of force added when the player jumps.

    [SerializeField] private LayerMask whatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform groundCheck;                           // A position marking where to check if the player is grounded.
    [SerializeField] SpriteRenderer spriteRenderer;

    const float groundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool grounded;            // Whether or not the player is grounded.
    private Rigidbody2D rb2D;

    float horizontalMove = 0f;
    bool jump = false;

    private void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * runSpeed * Time.deltaTime;

        transform.Translate(horizontalMove, 0, 0);

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }

        FlipCharacter();
    }

    private void FixedUpdate()
    {
        // Move our character
        Move(jump);
        jump = false;

        bool wasGrounded = grounded;
        grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = CombineArrays<Collider2D>(
            Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround),
            Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, LayerMask.GetMask("Clone"))
            );
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                grounded = true;
            }
        }
    }

    void Move(bool jump)
    {
        // If the player should jump...
        if (grounded && jump)
        {
            // Add a vertical force to the player.
            grounded = false;
            rb2D.AddForce(new Vector2(0f, jumpForce));
        }
    }

    void FlipCharacter()
    {
        if (horizontalMove > 0)
            spriteRenderer.flipX = false;
        if (horizontalMove < 0)
            spriteRenderer.flipX = true;
    } 

    private T[] CombineArrays<T>(T[] a, T[] b)
    {
        T[] combinedArray = new T[a.Length + b.Length];

        for(int i = 0; i < a.Length; i++)
            combinedArray[i] = a[i];
        for(int i = 0; i < b.Length; i++)
            combinedArray[i + a.Length] = b[i];

        return combinedArray;
    }
}
