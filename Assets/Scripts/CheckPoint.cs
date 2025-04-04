using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    private PlayerCheckPointLocations playerCheckPoint;
    public GameObject shopButton;
    public bool isPlayerInMarket;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag( "Player"))
        {
            playerCheckPoint.currentCheckPoint = transform.position;

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
        shopButton.SetActive(true);
    }

    void ExitMarketCheckPoint()
    {
        if (isPlayerInMarket == false)
        {
            shopButton.SetActive(false);
        }
    }
}
