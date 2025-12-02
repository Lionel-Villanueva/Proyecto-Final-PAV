using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadSceneManager : MonoBehaviour
{
    public void LoadScene(string scene)
    {
        try
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(scene);
        }
        catch(Exception e)
        {
            Debug.LogError("Error loading scene: " + e.Message);
        }
        
    }
    public void QuitGame()
    {
        Debug.Log("Saliste");
        Application.Quit();
    }
}
