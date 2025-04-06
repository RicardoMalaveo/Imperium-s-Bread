using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerHealth : MonoBehaviour
{
    //UI variables
    [SerializeField]
    private float InvulnerabilityTime = 0.2F;
    [SerializeField]
    private PickableObjectData pickableObjectData;
    [SerializeField]
    private PlayerCheckPointLocations PlayerCheckPoint;
    [SerializeField]
    private PlayerAttribute playerAttribute;
    [SerializeField]
    GameObject defeatScreen;
    private bool hit;
    public bool canBePushed;
    public bool playerIsDead;
    private int healingAmount = 20;

    private void Start()
    {
        playerAttribute.currentHealth = playerAttribute.playerBaseHealth;
        pickableObjectData.holyFlameCount = 5;
        if (PlayerCheckPoint.currentCheckPoint!= new Vector3(0,0,0))
        {
            transform.position = PlayerCheckPoint.currentCheckPoint;
        }
        else
        {
            PlayerCheckPoint.respawnPoint = new Vector3(-0.32842F, 6.297F, -0.04942882F);
        }

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

                defeatScreen.SetActive(true);
                Time.timeScale = 0;
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
