using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    [SerializeField] private TMP_Text _gearsText;
    [SerializeField] private TMP_Text _energyGemsText;

    public void UpdateResourceText(int m_gears, int m_energyGems)
    {
        _gearsText.text = "Gears Collected: " + m_gears.ToString();
        _energyGemsText.text = "Energy Gems Collected: " + m_energyGems.ToString();
    }
}
