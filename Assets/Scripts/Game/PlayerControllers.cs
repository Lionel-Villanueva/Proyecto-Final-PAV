using UnityEngine;

[RequireComponent(typeof(PlayerInputs))]

public class PlayerControllers : MonoBehaviour
{
    public static PlayerControllers Instance;

    public PlayerInputs InputManager;
    private PlayerAnimation AnimationController;
    public static int x;

    private void Awake()
    {
        if (Instance == null)

            Instance = this;

        InputManager = GetComponent<PlayerInputs>();
    }
    void Start()
    {

    }

    void Update()
    {
        
    }
}
