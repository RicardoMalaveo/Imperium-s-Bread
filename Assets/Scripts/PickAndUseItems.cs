using UnityEngine;

public class PickAndUseItems : MonoBehaviour
{
    public GameObject ricktus;
    [SerializeField]
    private PickableObjectData PickableObjectData;
    private int holyFlameMaxCount = 9;

    private void Awake()
    {
        if(PickableObjectData.holyFlameCount <= 0)
        {
            PickableObjectData.holyFlameCount = 5;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("HolyFlame"))
        {
            if(PickableObjectData.holyFlameCount <= holyFlameMaxCount)
            {
                PickableObjectData.holyFlameCount += 1;
            }
            Destroy(other);
        }
    }
}
