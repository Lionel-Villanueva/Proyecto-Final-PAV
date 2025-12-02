using UnityEngine;

[RequireComponent(typeof(PlayerInputs))]

public class PlayerControllers : MonoBehaviour
{
    public static PlayerControllers Instance;
    public PlayerInputs InputManager;
    public PlayerHealth PlayerHealth;
    public Rigidbody2D rb;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        InputManager = GetComponent<PlayerInputs>();
        PlayerHealth = GetComponent<PlayerHealth>();
        rb = GetComponent<Rigidbody2D>();
    }
}
