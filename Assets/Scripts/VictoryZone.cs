using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryZone : MonoBehaviour
{
    public  bool enemiesInVictoryZone = false;

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("FungalDemon"))
        {
            enemiesInVictoryZone = true;

        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("FungalDemon"))
        {
            enemiesInVictoryZone = false;

        }
    }
}
