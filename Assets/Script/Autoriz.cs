using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Autoriz : MonoBehaviour
{
    [Header("Fieds")]
    public InputField inputUserName;
    public InputField inputUserPassword;

    [Header("Nontif")]
    public GameObject notificationObject;
    public Animator notificationAnimator;

    public Text titleObject;
    public Text descriptionObject;

    public GameObject badNews;
    public GameObject goodNews;

    public string animationNameIn;
    public string animationNameOut;

    void Start()
    {
        notificationObject.SetActive(false);
    }
    public void ExitBtn()
    {
        Application.Quit();
    }
    private void Update()
    {
        if (inputUserName.isFocused)
        {
            inputUserName.placeholder.enabled = false;
        }
        if (inputUserPassword.isFocused)
        {
            inputUserPassword.placeholder.enabled = false;
        }
    }
    public void EnterBtn()
    {
        bool tryToLogin = false;
        if (inputUserName.text == "" || inputUserPassword.text == "")
        {
            ShowNotification("Упсик...", "Пустенько, заполните поля :)", false);
            tryToLogin = false;

        }
        else
        {
            for (int i = 0; i < PlayersDB.player.Length - 1; i++)
            {
                if (inputUserName.text == PlayersDB.GetDataValue(PlayersDB.player[i], "Login:"))
                {
                    if (inputUserPassword.text == PlayersDB.GetDataValue(PlayersDB.player[i], "Password:"))
                    {
                        tryToLogin = true;
                    }
                    break;
                }
            }

        }
        if (!tryToLogin)
        {
            ShowNotification("Ошибочка!", "Повторите ввод", false);
            inputUserName.text.Remove(0);
            inputUserPassword.text.Remove(0);
        }
        else
        {
            ShowNotification("Играть!", "Добро пожаловать!", true);
            SceneManager.LoadScene("NeverEndLevel");
        }
    }
    public void RegBtn()
    {
        SceneManager.LoadScene("Regisration");
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



}
