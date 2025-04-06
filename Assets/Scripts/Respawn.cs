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

            SceneManager.LoadScene(1);
        }
    }
}
