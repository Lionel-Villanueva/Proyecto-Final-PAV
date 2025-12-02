using System;
using UnityEngine;
public class FailCondition : MonoBehaviour
{
    public static event Action OnFailed;

    protected void Fail()
    {
        OnFailed?.Invoke();
    }
}
