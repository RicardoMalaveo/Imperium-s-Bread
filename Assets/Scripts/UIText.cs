using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class UIText : MonoBehaviour
{
    //UI variables
    [SerializeField]
    private TMP_Text playerLevel;
    [SerializeField]
    private TMP_Text holyFlameCount;
    [SerializeField]
    private TMP_Text CurrentPlayerHP;
    [SerializeField]
    private TMP_Text BaseHP;
    [SerializeField]
    private TMP_Text FavoursCount;
    [SerializeField]
    private PlayerAttribute PlayerAttribute;
    [SerializeField]
    private PickableObjectData PickableObject;

    public void Update()
    {
        playerLevel.text = "Level " + PlayerAttribute.playerCurrentLevel.ToString();
        FavoursCount.text = PickableObject.favoursCount.ToString();
        holyFlameCount.text = PickableObject.holyFlameCount.ToString();
        CurrentPlayerHP.text ="/ " +PlayerAttribute.currentHealth.ToString();
        BaseHP.text = PlayerAttribute.playerBaseHealth.ToString();
    }

}
