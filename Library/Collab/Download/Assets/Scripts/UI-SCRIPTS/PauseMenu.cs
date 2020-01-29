using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;



    private void Start()
    {
        Resume();
    }

    void Update () {
        if (Input.GetButtonDown("Cancel"))
        {
            GameIsPaused = true;

            if (GameIsPaused)
            {
                Pause();

            } else
            {
                Resume();
            }
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void BackToMenu()
    {
        GameIsPaused = false;
        SceneManager.LoadScene(0);
  
    }
    public void ResumeGameF()
    {
        Resume();
    }
}
