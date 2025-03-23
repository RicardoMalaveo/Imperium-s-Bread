using System.Collections;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public IEnumerator CameraShake(float duration)
    {
        float shakeQuantity = 0.5F;
        Vector3 originalLoc = transform.localPosition;

        while  (duration > 0)
        {
            transform.localPosition = originalLoc + Random.insideUnitSphere * shakeQuantity;
            duration -= Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalLoc;
    }
}
