using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    private Vector2 direction;

    private void Start()
    {
        PlayerControllers.Instance.InputManager.OnMoveChange += Move;
    }
    private void OnDestroy()
    {
        PlayerControllers.Instance.InputManager.OnMoveChange -= Move;
    }
    private void FixedUpdate()
    {
        PlayerControllers.Instance.rb.linearVelocity = new Vector2(direction.x * speed, PlayerControllers.Instance.rb.linearVelocity.y);
    }
    private void Move(Vector2 value)
    {
        direction = value;
    }

}
