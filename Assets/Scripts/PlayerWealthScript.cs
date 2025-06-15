using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWealthScript : MonoBehaviour
{
    [SerializeField] private int _gearsCollected = 0;

    public void CollectGear(int m_gearAmount)
    {
        Debug.Log("Play gear collection sound here");
        _gearsCollected += m_gearAmount;
    }
}
