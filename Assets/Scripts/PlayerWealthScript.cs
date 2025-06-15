using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWealthScript : MonoBehaviour
{
    [SerializeField] private int _gearsCollected = 0;
    [SerializeField] private int _energyGemsCollected = 0;

    public void CollectDrop(int m_gearAmount, int m_energyGemAmount)
    {
        Debug.Log("Play gear collection sound here");
        _gearsCollected += m_gearAmount;
        Debug.Log("Play energy gem collection sound here");
        _energyGemsCollected += m_energyGemAmount;
    }
}
