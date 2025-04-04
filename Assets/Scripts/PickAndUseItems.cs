using UnityEngine;

public class PickAndUseItems : MonoBehaviour
{
    public GameObject ricktus;
    public GameManager gameManager;

     void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("HolyFlame"))
        {
            if(gameManager.holyFlameCount <= gameManager.holyFlareMaxCount)
            {
                gameManager.holyFlameCount += 1;
            }
            Destroy(other);
        }
    }
}
