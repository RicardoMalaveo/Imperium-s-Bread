using NUnit.Framework;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using TMPro;
public class PlayerHealth : MonoBehaviour
{
    //UI variables
    [SerializeField]
    private TMP_Text holyFlameCount;
    [SerializeField]
    private TMP_Text CurrentPlayerHP;
    [SerializeField]
    private TMP_Text FavoursCount;
    [SerializeField]

    private float InvulnerabilityTime = 0.2F;
    [SerializeField]
    private PickableObjectData pickableObjectData;
    [SerializeField]
    private PlayerCheckPointLocations PlayerCheckPoint;
    [SerializeField]
    private PlayerAttribute playerAttribute;
    private bool hit;
    public bool canBePushed;
    public bool playerIsDead;
    private int healingAmount = 20;

    private void Start()
    {
        transform.position = PlayerCheckPoint.currentCheckPoint;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
                Healing();
        }
    }
    public void Damage(int weaponDamage)
    {
        if (!hit && playerAttribute.currentHealth > 0)
        {
            hit = true;
            Debug.Log("Dealing damage");
            playerAttribute.currentHealth -= weaponDamage;

            if (playerAttribute.currentHealth <= 0)
            {
                playerIsDead = true;
                playerAttribute.currentHealth = 0;
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
        if (pickableObjectData.holyFlameCount <= 0)
        {
            Debug.Log("can't heal");
        }
        else
        {
            Debug.Log("Healing");
            pickableObjectData.holyFlameCount -= 1;

            if (playerAttribute.currentHealth < playerAttribute.playerBaseHealth)
            {
            if(playerAttribute.currentHealth + healingAmount > playerAttribute.playerBaseHealth)
            {
                playerAttribute.currentHealth = playerAttribute.playerBaseHealth;
            }
            else
            {
                playerAttribute.currentHealth += healingAmount;
            }
            }
        }
    
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Trap"))
        {
            Damage(20);
        }
    }

    private IEnumerator TurnOffHit()
    {
        yield return new WaitForSeconds(InvulnerabilityTime);

        hit = false;
    }
}
