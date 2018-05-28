using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{

    public static bool pause = false;
    public GameObject PauseMenueUi;
    public string LevelName;
    public GameObject DieScreen;
    public GameObject PlayerModel;
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }


    }
    public void Pause()
    {
        PauseMenueUi.SetActive(true);
        Time.timeScale = 0;
        pause = true;
    }
    public void Resume()
    {
        PauseMenueUi.SetActive(false);
        Time.timeScale = 1;
        pause = false;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(LevelName);
        Time.timeScale = 1;
        PauseScript.pause = false;
    }

    public void DieResume()
    {
        SceneManager.LoadScene(LevelName);
        Time.timeScale = 1;
        PauseScript.pause = false;
    }



}
