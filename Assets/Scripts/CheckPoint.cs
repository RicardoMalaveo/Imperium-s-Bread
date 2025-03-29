using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameManager gM;

    void Start()
    {
        gM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag( "Player"))
        {
            Debug.Log("Checkpoint Reached");

            gM.lastCheckPoint = transform.position;
        }
    }
}
