using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class CameraBehavior : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector3 offset;
    public float followSpeed;

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

    public void MoveToTarget()
    {
        Vector3 targerPosition = new Vector3(objectToFollow.transform.position.x + offset.x, objectToFollow.transform.position.y + offset.y, objectToFollow.transform.position.z + offset.z);
        transform.position = Vector3.Lerp(transform.position, targerPosition, followSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        MoveToTarget();
    }
}
