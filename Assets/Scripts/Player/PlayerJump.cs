using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayerJump : MonoBehaviour
{
    [Header("Raycast")]
    [SerializeField] private float distance;
    [SerializeField] private LayerMask layer;

    public float jumpForce = 12f;
    private bool isJump;
    private void Start()
    {
        PlayerControllers.Instance.InputManager.OnJumpPerformed += Jump;
    }
    private void OnDestroy()
    {
        PlayerControllers.Instance.InputManager.OnJumpPerformed += Jump;
    }
    private void Jump(bool value)
    {
        isJump = value;
    }
    private void FixedUpdate()
    {
        if (isJump && IsGrounded())
        {
            Debug.Log("esttro");
            PlayerControllers.Instance.rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down,distance,layer);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * distance);
    }
}
