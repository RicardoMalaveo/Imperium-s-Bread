using NUnit.Framework;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float InvulnerabilityTime = 0.2F;

    private bool hit;
    public bool canBePushed;

    public int currentHealth = 100;

    public void Damage(int weaponDamage)
    {
        if (!hit && currentHealth > 0)
        {
            hit = true;
            Debug.Log("Dealing damage");
            currentHealth -= weaponDamage;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                gameObject.SetActive(false);
            }
            else
            {
                StartCoroutine(TurnOffHit());
            }
        }
    }

    private IEnumerator TurnOffHit()
    {
        yield return new WaitForSeconds(InvulnerabilityTime);

        hit = false;
    }
}
