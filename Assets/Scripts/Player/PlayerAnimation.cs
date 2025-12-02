using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class PlayerAnimation : MonoBehaviour
{
    public Animator controller;
    public SpriteRenderer sprite;
    public bool IsMoving;

    private void Awake()
    {
        controller = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        PlayerControllers.Instance.InputManager.OnMoveChange += SetMoveAnimation;

        PlayerControllers.Instance.InputManager.OnJumpPerformed += SetJumpAnimation;
    }
    
    private void SetJumpAnimation(bool value)
    {
        controller.SetTrigger("OnJump");
        print("Jump");
    }

    private void SetMoveAnimation(Vector2 vector)
    {
        if (vector.x == 0)
            return;
         
        if (vector.x != 0)
            controller.SetBool("IsMoving", true);
        else
            controller.SetBool("IsMoving", false);

        if (vector.x >= 0)
            sprite.flipX = true;
        else
            sprite.flipX = false;

    }
    private void Dead()
    {
    }
}
