using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private PickableObjectData pickableObjectData;
    [SerializeField]
    private PlayerAttribute PlayerAttribute;
    public GameObject shopButton;
    public GameObject shopMenu;

    public void OpenShop()
    {
        shopButton.SetActive(false);
        shopMenu.SetActive(true);
        Time.timeScale = 0F;
    }

    public void BuyHolyFlame()
    {
        if (pickableObjectData.favoursCount >= pickableObjectData.holyFlamePrice)
        {
            pickableObjectData.favoursCount -= pickableObjectData.holyFlamePrice;
            pickableObjectData.holyFlameCount += 3;
        }
    }

    public void LevelUp()
    {
        if(pickableObjectData.favoursCount >= PlayerAttribute.favoursPricePerLevel)
        {
            pickableObjectData.favoursCount -= PlayerAttribute.favoursPricePerLevel;
            PlayerAttribute.playerCurrentLevel += 1;
            PlayerAttribute.playerBaseAttack += 5;
            PlayerAttribute.playerBaseHealth += 10;
        }
    }

    public void CloseShop()
    {
        shopButton.SetActive(true);
        shopMenu.SetActive(false);
        Time.timeScale = 1F;
    }
}
