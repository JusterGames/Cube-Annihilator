using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private bool gameIsPaused = false;
    private GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = transform.GetChild(0).gameObject;
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // press esc to pause or unpause game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (!gameIsPaused)
        {
            gameIsPaused = true;
            // Show the pause menu
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            // Game is already paused
            gameIsPaused = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void RestartScene()
    {
        // Reload the currently active scene by its build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
