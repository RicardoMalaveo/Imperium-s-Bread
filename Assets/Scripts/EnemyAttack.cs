using NUnit.Framework;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private int weaponDamage = 20;

    public CapsuleCollider frontCol;

    public PlayerHealth playerHealth;

    public EnemyBehavior enemyBehavior;

    bool canAttack = true;


    private bool collided;

    private bool Strike;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }


    private void FixedUpdate()
    {
        if (enemyBehavior.startAttack)
        {
            if(!frontCol.enabled && canAttack)
            {
                canAttack = false;
                StartCoroutine(AttackReset());
            }
        }


        if (Strike == true)
        {
            Debug.Log("dealing damage to the player");
            playerHealth.Damage(weaponDamage);
            Strike = false;
            frontCol.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Strike = true;
            Debug.Log(col.gameObject.CompareTag("Player"));
        }
    }

    private IEnumerator AttackReset()
    {
        yield return new WaitForSeconds(1F);
        frontCol.enabled = true;
        StartCoroutine(Attack());
    }
    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.2F);
        frontCol.enabled = false;
        StartCoroutine(AttackDownTime());
    }
    private IEnumerator AttackDownTime()
    {
        Debug.Log("downtime");
        yield return new WaitForSeconds(1);
        canAttack = true;
    }
}
