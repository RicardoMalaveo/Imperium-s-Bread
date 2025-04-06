using System;
using System.Collections;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class KnifeAttack : MonoBehaviour
{
    [SerializeField]
    private int weaponDamage = 20;

    public CapsuleCollider frontKnifeCol;
    public CapsuleCollider backKnifeCol;

    private MeleeAttackManager meleeAttackManager;

    private Vector3 attackDirection;

    [SerializeField]
    private EnemyHealth enemyHealth;

    private bool collided;

    [SerializeField]
    private bool Strike;

    private void FixedUpdate()
    {
       if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            frontKnifeCol.enabled = true;
            backKnifeCol.enabled = true;
        }
       else
        {
            frontKnifeCol.enabled = false;
            backKnifeCol.enabled = false;
        }


       if (Strike == true)
        {
            Strike = false;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("FungalDemon"))
        {
            EnemyHealth enemyHealth = col.GetComponent<EnemyHealth>();
            Debug.Log("Attacking enemy");
            enemyHealth.Damage(weaponDamage);
            Strike = true;
        }
    }     
}
