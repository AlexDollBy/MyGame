using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void NewGameBtn()
    {
        SceneManager.LoadScene("Autorization");
    }

    public void ExitBtn()
    {
        Application.Quit();
    }
    public void RegBtn()
    {
        SceneManager.LoadScene("Regisration");
    }
}
