using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopButton;
    public GameObject shopMenu;
    public void OpenShop()
    {
        shopButton.SetActive(false);
        shopMenu.SetActive(true);
        Time.timeScale = 0F;
    }

    public void CloseShop()
    {
        shopButton.SetActive(true);
        shopMenu.SetActive(false);
        Time.timeScale = 1F;
    }

}
