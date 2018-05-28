using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Registration : MonoBehaviour {

    public InputField login;
    public InputField password;
    string CreateUserURL = "http://bymy.org/scgi-bin/InsertUser.php";

    [Header("OBJECT")]
    public GameObject notificationObject;
    public Animator notificationAnimator;
    public string LevelName;


    public Text titleObject;
    public Text descriptionObject;

    public GameObject panelRegistr;
    public GameObject panelAutariz;

    public GameObject badNews;
    public GameObject goodNews;

    public string animationNameIn;
    public string animationNameOut;

    private void Update ()
    {
        if (login.isFocused)
        {
            login.placeholder.enabled = false;
        }
        if (password.isFocused)
        {
            password.placeholder.enabled = false;
        }
    }

    void CreateUser(string userName, string userPassword)
    {
        CreateUserURL += "?usernamePost=" + userName + "&passwordPost=" + userPassword;
        WWW www = new WWW(CreateUserURL);
        www.ToString();
    }
    public void RegistrationBtn()
    {
        bool tryToLogin = true;
        if (login.text == "" || password.text == "")
        {
            ShowNotification("Упсик...", "Пустенько :)", false);
            tryToLogin = false;

        }
        else
        {
            for (int i = 0; i < PlayersDB.player.Length - 1; i++)
            {
                if (login.text == PlayersDB.GetDataValue(PlayersDB.player[i], "Login:"))
                {
                    login.text = "";
                    password.text = "";
                    ShowNotification("Охохоюшки", "Придумай новенький\n логин", false);

                    tryToLogin = false;
                    break;
                }
            }

        }
        if (tryToLogin)
        {
            CreateUser(login.text, password.text);
            SceneManager.LoadScene("Autorization");
        }
    }

    public void ShowNotification(string titleText, string descriptionText, bool news)
    {
        if (news)
        {
            badNews.SetActive(false);
            goodNews.SetActive(true);
        }
        else
        {
            badNews.SetActive(true);
            goodNews.SetActive(false);
        }
        notificationObject.SetActive(true);
        titleObject.text = titleText;
        descriptionObject.text = descriptionText;
        notificationAnimator.Play(animationNameIn);
        notificationAnimator.Play(animationNameOut);
    }
    public void CleanAll()
    {
        login.text = "";
        password.text = "";
    }
    public void ExitBtn()
    {
        Application.Quit();
    }
}
