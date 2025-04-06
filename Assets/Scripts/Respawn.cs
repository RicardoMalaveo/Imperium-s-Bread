using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TreeEditor;

public class Respawn : MonoBehaviour
{
    [SerializeField]
    private VictoryZone victoryZone;
    [SerializeField]
    private PlayerCheckPointLocations playerCheckPoint;
    [SerializeField]
    private PlayerAttribute PlayerAttribute;
    [SerializeField]
    private PickableObjectData PickableObjectData;
    [SerializeField]
    bool playerInVictoryArea = false;
    [SerializeField]
    GameObject victoryScreen;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("DeadZone"))
        {
            transform.position = playerCheckPoint.currentCheckPoint;

            SceneManager.LoadScene(1);
        }

        if (col.gameObject.CompareTag("VictoryZone"))
        {
            Debug.Log("Player In victory area");
            playerInVictoryArea= true;

            if (playerInVictoryArea && !victoryZone.enemiesInVictoryZone)
            {
                victoryScreen.SetActive(true);

                Time.timeScale = 0;
            }
        }
    }
}
