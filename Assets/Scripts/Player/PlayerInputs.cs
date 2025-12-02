using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    public MainInput inputs;
    public Action<Vector2> OnMoveChange;
    public Action<bool> OnJumpPerformed;

    private Vector2 moveInput;

    private void Awake()
    {
        inputs = new MainInput();
    }
    private void OnEnable()
    {
        inputs.Enable();
        inputs.Player.Move.started += OnMove;
        inputs.Player.Move.performed += OnMove;
        inputs.Player.Move.canceled += OnMove;

        inputs.Player.Jump.started += OnJump;
        inputs.Player.Jump.performed += OnJump;
        inputs.Player.Jump.canceled += OnJump;
    }
    private void OnDisable()
    {
        inputs.Disable();
        inputs.Player.Move.started -= OnMove;
        inputs.Player.Move.performed -= OnMove;
        inputs.Player.Move.canceled -= OnMove;

        inputs.Player.Jump.started -= OnJump;
        inputs.Player.Jump.performed -= OnJump;
        inputs.Player.Jump.canceled -= OnJump;
    }
    private void OnJump(InputAction.CallbackContext context)
    {
        OnJumpPerformed?.Invoke(context.performed);
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        OnMoveChange?.Invoke(moveInput);
    }


    public Vector2 Moveinputs => moveInput;
}
