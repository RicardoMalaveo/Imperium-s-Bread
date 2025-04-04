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

    public EnemyHealth enemyHealth;

    private bool collided;

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
            Debug.Log("Attacking enemy");
            enemyHealth.Damage(weaponDamage);
            Strike = false;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("FungalDemon"))
        {
            Strike = true;
        }
    }

        
}
