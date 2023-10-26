using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour
{
    public void LoadScene(string sceneName = "Main Menu")
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene(int buildIndex = 0)
    {
        SceneManager.LoadScene(buildIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Quiting Game...");
        Application.Quit();
    }
}    
