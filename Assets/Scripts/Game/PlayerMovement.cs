using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    public float jumpForce = 12f;

    private Rigidbody2D rb;
    private PlayerController inputs;

    public Animator animator;
    
    private float horizontal;
    private bool jumpRequested;

    [Header("Ground Detection")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputs = new PlayerController();

        inputs.Player.Move.performed += ctx => horizontal = ctx.ReadValue<float>();
        inputs.Player.Move.canceled += ctx => horizontal = 0f;

        inputs.Player.Jump.performed += ctx => jumpRequested = true;
    }

    private void OnEnable() => inputs.Player.Enable();
    private void OnDisable() => inputs.Player.Disable();

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
        animator.SetFloat("Movement", Mathf.Abs(horizontal));
        if (rb.linearVelocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (rb.linearVelocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (jumpRequested && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        jumpRequested = false;
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
    
}
