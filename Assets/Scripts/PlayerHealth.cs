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

    private bool hit;
    public bool canBePushed;
    public bool playerIsDead;
    public int currentHealth = 100;

    private GameManager gM;

    void Start()
    {
        gM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();

        transform.position = gM.lastCheckPoint;
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
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                transform.position = gM.lastCheckPoint;
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
