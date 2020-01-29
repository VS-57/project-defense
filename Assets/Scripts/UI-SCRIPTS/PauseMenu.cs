using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject RespawnCanvas;
    public GameObject shop;

    private void Start()
    {
        
    }
    void Update () {

        if(!GameObject.FindGameObjectWithTag("Player"))
        {
            RespawnUI();
            SceneManager.LoadScene(0);
        }
    }

    void RespawnUI()
    {
        RespawnCanvas.SetActive(true);
    }


    public void BackToMenu()
    {
        GameIsPaused = false;
        SceneManager.LoadScene(0);
  
    }


    public void Respawn()
    {
        SceneManager.LoadScene(1);
    }
}
