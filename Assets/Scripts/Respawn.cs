using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TreeEditor;

public class Respawn : MonoBehaviour
{
    [SerializeField]
    private PlayerCheckPointLocations playerCheckPoint;
    [SerializeField]
    private PlayerAttribute PlayerAttribute;
    [SerializeField]
    private PickableObjectData PickableObjectData;

    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("DeadZone"))
        {
            transform.position = playerCheckPoint.currentCheckPoint;
            PlayerAttribute.currentHealth = PlayerAttribute.playerBaseHealth;
            PickableObjectData.holyFlameCount = 5;

            SceneManager.LoadScene(1);
        }
    }
}
