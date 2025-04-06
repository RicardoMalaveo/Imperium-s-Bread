using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryZone : MonoBehaviour
{
    public  bool enemiesInVictoryZone;

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("FungalDemon"))
        {
            Debug.Log("enemy gone");
            enemiesInVictoryZone = false;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("FungalDemon"))
        {
            Debug.Log("enemies in the area");
            enemiesInVictoryZone = true;
        }
    }
}
