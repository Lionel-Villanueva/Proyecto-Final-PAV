using System;
using UnityEngine;
public class WinCondition : MonoBehaviour
{
    public static event Action OnCompleted;
    protected void Complete()
    {
        OnCompleted?.Invoke();
    }
}
