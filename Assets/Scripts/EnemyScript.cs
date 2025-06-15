using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private int _health = 3; //the health of this enemy
    public void InflictDamage(int m_damageTaken)
    {
        _health -= m_damageTaken;
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (_health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
