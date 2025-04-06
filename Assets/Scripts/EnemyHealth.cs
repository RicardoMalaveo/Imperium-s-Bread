using NUnit.Framework;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float InvulnerabilityTime = 0.2F;
    [SerializeField]
    private PickableObjectData PickableObjectData;
    public GameObject holyFlame;
    private int favourPoints = 10;
    [SerializeField]
    private bool hit;
    public bool canBePushed;

    [SerializeField]
    private int currentHealth = 100;

    public void Damage(int weaponDamage)
    {
        if(!hit && currentHealth > 0)
        {
            hit = true;
            Debug.Log("Dealing damage");
            currentHealth -= weaponDamage;

            if (currentHealth <= 0)
            {
                StartCoroutine(Dying());

                //enemy gets destroyed and there are particle effects on the place, along with items.
            }
            else
            {
                StartCoroutine(TurnOffHit());
            }
        }
    }

    void DropItem()
    {
        int randomNumber = Random.Range(1, 3);
        if(randomNumber <= 1 )
        {
            Instantiate(holyFlame, transform.position,Quaternion.identity);
        }
    }
    private IEnumerator TurnOffHit()
    {
        yield return new WaitForSeconds(InvulnerabilityTime);
        hit = false;
    }

    private IEnumerator Dying()
    {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5F);
        currentHealth = 0;
        DropItem();
        PickableObjectData.favoursCount += favourPoints;
        Destroy(gameObject);
    }

}
