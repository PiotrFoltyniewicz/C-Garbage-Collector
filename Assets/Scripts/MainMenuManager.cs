using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void GoToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
