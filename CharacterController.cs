using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Animator animator;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isAttacking;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input from the player
        float moveInput = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Update the animator with the speed value
        animator.SetFloat("speed", Mathf.Abs(moveInput));

        // Move the character
        rb.linearVelocity = movement;

        // Check if the character is grounded
        isGrounded = Physics2D.OverlapCircle(transform.position, 0.1f, groundLayer);

        // Jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Attack with Shift key
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            isAttacking = true;
            Attack();
        }
        else
        {
            isAttacking = false;
        }

        // Update the animator with the attack state
        animator.SetBool("isAttacking", isAttacking);
    }

    void Attack()
    {
        // Your attack logic here
        Debug.Log("Attack executed");
    }
}
