using NUnit.Framework;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float InvulnerabilityTime = 0.2F;
    [SerializeField]
    private PickableObjectData pickableObjectData;
    [SerializeField]
    private PlayerCheckPointLocations PlayerCheckPoint;
    private bool hit;
    public bool canBePushed;
    public bool playerIsDead;
    public int currentHealth = 100;
    private int maxHealth = 100;
    private int healingAmount = 20;

    private void Start()
    {
        transform.position = PlayerCheckPoint.currentCheckPoint;
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(pickableObjectData.holyFlameCount <= 0)
            {
                Debug.Log("can't heal");
            }
            else
            {
                pickableObjectData.holyFlameCount -= 1;
                Healing();
            }
        }
    }
    public void Damage(int weaponDamage)
    {
        if (!hit && currentHealth > 0)
        {
            hit = true;
            Debug.Log("Dealing damage");
            currentHealth -= weaponDamage;

            if (currentHealth <= 0)
            {
                playerIsDead = true;
                currentHealth = 0;
                SceneManager.LoadScene(1);
                transform.position = PlayerCheckPoint.currentCheckPoint;
            }
            else
            {
                StartCoroutine(TurnOffHit());
            }
        }
    }

    void Healing()
    {
        if(currentHealth< maxHealth)
        {
            if(currentHealth + healingAmount > maxHealth)
            {
                currentHealth = maxHealth;
            }
            else
            {
                currentHealth += healingAmount;
            }
        }
    }

    private IEnumerator TurnOffHit()
    {
        yield return new WaitForSeconds(InvulnerabilityTime);

        hit = false;
    }
}
