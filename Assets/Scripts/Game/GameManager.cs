using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action OnGameWin;
    public static event Action OnGameFail;
    private void OnEnable()
    {
        WinCondition.OnCompleted += HandleWin;
        FailCondition.OnFailed += HandleFail;
    }
    private void OnDisable()
    {
        WinCondition.OnCompleted -= HandleWin;
        FailCondition.OnFailed -= HandleFail;
    }
    private void HandleWin()
    {
        OnGameWin?.Invoke();
        StopGame();
    }
    private void HandleFail()
    {
        OnGameFail?.Invoke();
        StopGame();
    }
    public void StopGame()
    {
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
}
