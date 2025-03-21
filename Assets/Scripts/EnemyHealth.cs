using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private bool damageable = true;
    [SerializeField]
    private int totalHealth = 100;
    [SerializeField]
    public float InvulnerabilityTime = 0.2F;

    private bool hit;
    public bool canBePushed;

    private int currentHealth;

    public void Damage(int amount)
    {
        if(damageable && !hit && currentHealth > 0)
        {
            hit = true;

            currentHealth -= amount;

            if (currentHealth <=0)
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
