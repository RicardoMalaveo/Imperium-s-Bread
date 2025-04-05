using System.Collections;
using UnityEngine;

public class EnviromentalHazard : MonoBehaviour
{
    [SerializeField]
    private SphereCollider trapCollider;
    [SerializeField]
    private float radiusScaleSpeed;
    [SerializeField]
    private float radiusMaxScale = 3.8F;
    [SerializeField]
    private Vector3 radiusInitialScale;
    public int intialBurst = 2;
    bool bubbleBurst = true;
    private float timeElapsed = 0;
    public float burstDuration = 3F;
    public float downTime = 5F;

    void Start()
    {
        StartCoroutine(BubbleTrapRoutine());
        radiusInitialScale = transform.localScale;
    }
    private void Update()
    {
        if (timeElapsed < burstDuration && !bubbleBurst)
        {
            radiusScaleSpeed = timeElapsed / burstDuration;
            trapCollider.transform.localScale = transform.localScale = Vector3.Lerp(transform.localScale, radiusInitialScale * radiusMaxScale, radiusScaleSpeed * Time.deltaTime);
            timeElapsed += Time.deltaTime;
        }
    }
    private IEnumerator BubbleTrapRoutine()
    {
        yield return new WaitForSeconds(intialBurst);
        trapCollider.enabled = true;
        bubbleBurst = false;
        yield return new WaitForSeconds(burstDuration);
        bubbleBurst = true;
        trapCollider.enabled = false;
        trapCollider.transform.localScale = radiusInitialScale;
        timeElapsed = 0;
        yield return new WaitForSeconds(downTime);
        StartCoroutine(BubbleTrapRoutine());
    }
}
