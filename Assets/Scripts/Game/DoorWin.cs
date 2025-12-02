using UnityEngine;

public class DoorWin : WinCondition
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Complete();
        }
    }
}
