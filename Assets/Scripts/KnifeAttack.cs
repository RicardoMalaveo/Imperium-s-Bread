using System.Collections;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class KnifeAttack : MonoBehaviour
{
    [SerializeField]
    private int damageAmount = 40;

    private Character player;

    private Rigidbody kitchenKnife;

    //private MeleeAttackManager meleeAttackManager;

    private Vector3 attackDirection;

    private bool collided;

    private bool forwardStrike;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<Character>();

        kitchenKnife = GetComponent<Rigidbody>();

        //meleeAttackManager = GetComponent<MeleeAttackManager>();

    }

    private void FixedUpdate()
    {
        AttackMovement();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<EnemyHealth>())
        {
            CollisionHandler(collision.GetComponent<EnemyHealth>());
        }
        
    }

    private void CollisionHandler(EnemyHealth enemyHealth)
    {
        if(enemyHealth.canBePushed && Input.GetAxis("Vertical") < 0)
        {
            attackDirection = Vector3.forward;

            forwardStrike = true;

            collided = true;
        }

        if(enemyHealth.canBePushed && Input.GetAxis("Vertical") > 0)
        {
            attackDirection = Vector3.back;

            forwardStrike = true;

            collided = true;
        }

        if (enemyHealth.canBePushed && Input.GetAxis("Horizontal") < 0)
        {
            attackDirection = new Vector3(0, 0, -1);

            forwardStrike = true;

            collided = true;
        }

        if (enemyHealth.canBePushed && Input.GetAxis("Horizontal") > 0)
        {
            attackDirection = new Vector3( 0, 0, 1);

            forwardStrike = true;

            collided = true;
        }

        enemyHealth.Damage(damageAmount);

        //StartCoroutine(NolongerColliding());
    }

    private void AttackMovement()
    {
        if(forwardStrike)
        {
            //kitchenKnife.AddForce(attackDirection * meleeAttackManager.upwardsForce);
        }
        else 
        {
            //kitchenKnife.AddForce(attackDirection * meleeAttackManager.backForce);
        }
    }

    //private IEnumerator NolongerColliding()
    //{
    //    yield return new WaitForSeconds(meleeAttackManager.movementRime);

    //    collided = false;
    //    forwardStrike = false;
    //}
}
