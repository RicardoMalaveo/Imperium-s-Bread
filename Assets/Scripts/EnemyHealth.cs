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
    public GameManager gameManager;
    public GameObject holyFlame;
    private int favourPoints = 10;
    private bool hit;
    public bool canBePushed;

    public int currentHealth = 100;

    public void Damage(int weaponDamage)
    {
        if(!hit && currentHealth > 0)
        {
            hit = true;
            Debug.Log("Dealing damage");
            currentHealth -= weaponDamage;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Destroy(gameObject);
                DropItem();
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
        gameManager.favourPoints += 10;
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
}
