using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject failPanel;

    private void OnEnable()
    {
        GameManager.OnGameWin += ShowWinUI;
        GameManager.OnGameFail += ShowFailUI;
    }
    private void OnDisable()
    {
        GameManager.OnGameWin -= ShowWinUI;
        GameManager.OnGameFail -= ShowFailUI;
    }
    private void ShowWinUI()
    {
        winPanel.gameObject.SetActive(true);
    }
    private void ShowFailUI()
    {
        failPanel.gameObject.SetActive(true);
    }

}
