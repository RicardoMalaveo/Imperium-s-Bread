using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameManager GameManager;
    public GameObject menuButton;
    public GameObject mainMenu;
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Play()
    {
        GameManager.lastCheckPoint =new Vector3(-0.32842F, 6.297F, -0.04942882F);
        SceneManager.LoadScene(1);
        Time.timeScale = 1F;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        menuButton.SetActive(false);
        mainMenu.SetActive(true);

        Time.timeScale = 0F;
    }
    public void Continue()
    {
        menuButton.SetActive(true);
        mainMenu.SetActive(false);

        Time.timeScale = 1F;
    }

}
