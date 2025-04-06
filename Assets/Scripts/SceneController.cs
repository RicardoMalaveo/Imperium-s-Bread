using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private PickableObjectData PickableObjectData;
    [SerializeField]
    private PlayerCheckPointLocations playerCheckPoint;
    [SerializeField]
    private PlayerAttribute PlayerAttribute;
    public GameObject menuButton;
    public GameObject mainMenu;
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Play()
    {
        PlayerAttribute.playerBaseAttack = 20;
        PlayerAttribute.playerBaseHealth = 100;
        PlayerAttribute.playerCurrentLevel = 1;
        PlayerAttribute.favoursPricePerLevel = 20;

        PlayerAttribute.currentHealth = 100;
        PickableObjectData.holyFlameCount = 5;
        PickableObjectData.favoursCount = 0;
        playerCheckPoint.respawnPoint = new Vector3(-0.32842F, 6.297F, -0.04942882F);
        SceneManager.LoadScene(1);
        playerCheckPoint.currentCheckPoint = playerCheckPoint.respawnPoint;
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
        if(PlayerAttribute.currentHealth <= 0)
        {
            PlayerAttribute.currentHealth = PlayerAttribute.playerBaseHealth;
            PickableObjectData.holyFlameCount = 5;
            if (playerCheckPoint.currentCheckPoint != new Vector3(0, 0, 0))
            {
                transform.position = playerCheckPoint.currentCheckPoint;
                SceneManager.LoadScene(1);
            }
            else
            {
                playerCheckPoint.respawnPoint = new Vector3(-0.32842F, 6.297F, -0.04942882F);
                SceneManager.LoadScene(1);
            }
        }
        menuButton.SetActive(true);
        mainMenu.SetActive(false);

        Time.timeScale = 1F;
    }

}
