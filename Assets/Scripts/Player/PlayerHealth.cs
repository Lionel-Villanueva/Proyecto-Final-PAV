using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public bool isDead = false;
    private void Dead()
    {
        isDead = true;
    }
}
