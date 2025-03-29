using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{

    private GameManager gM;
    void Start()
    {
        gM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();

        transform.position = gM.lastCheckPoint;
    }
    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("DeadZone"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
