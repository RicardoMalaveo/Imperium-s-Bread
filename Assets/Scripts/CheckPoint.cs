using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameManager gM;
    public GameObject shopButton;
    public bool isPlayerInMarket;

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

            isPlayerInMarket = true;
            EnterMarketCheckpoint();
        }
    }

    void OnTriggerExit(Collider other)
    {
        {
            if (other.CompareTag("Player"))
            {
                isPlayerInMarket = false;
                ExitMarketCheckPoint();

            }
        }
    }

    void EnterMarketCheckpoint()
    {
        Debug.Log("Player entered the area");
        shopButton.SetActive(true);
            //if player press button
            // show store items in UI and exit button
            //if user press exit button
            //run ExitMarketCheckPoint() to close shop
    }

    void ExitMarketCheckPoint()
    {
        if (isPlayerInMarket == false)
        {
            Debug.Log("Player Left the area");
            shopButton.SetActive(false);
        }
        //only shuts the shop down

    }
}
