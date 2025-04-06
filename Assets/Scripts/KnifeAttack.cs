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

    [SerializeField]
    private RicktusAnimations ricktusAnimations;
    public bool attacking;
    private float attackDuration = 0.5F;
    private float attackHit = 0.1F;

    [SerializeField]
    private bool Strike;

    private void FixedUpdate()
    {
        if(!attacking)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                attacking = true;
                StartCoroutine(Attacking());
            }
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

    private IEnumerator Attacking()
    {
        ricktusAnimations.SetAnimations(ricktusAnimations.attacking, true, 1f);
        yield return new WaitForSeconds(attackDuration);
        frontKnifeCol.enabled = true;
        backKnifeCol.enabled = true;
        yield return new WaitForSeconds(0.2f);
        frontKnifeCol.enabled = false;
        backKnifeCol.enabled = false;
        yield return new WaitForSeconds(attackHit);
        attacking = false;
    }
}
