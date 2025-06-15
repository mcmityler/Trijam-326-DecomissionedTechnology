using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private int _health = 3; //the health of this enemy
    [SerializeField] private GameObject _gearDropObj; //the gear object this thing drops
    [SerializeField] private float _dropRate = 3; //can drop up to whatever number this is set to
    public void InflictDamage(int m_damageTaken)
    {
        _health -= m_damageTaken;
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (_health <= 0)
        {
            //generate drops
            
            int numOfGearsToDrop = Mathf.FloorToInt(Random.Range(0, _dropRate)) + 1;
            for (int i = 0; i < numOfGearsToDrop; i++)
            {
                Instantiate(_gearDropObj, this.gameObject.transform.position, Quaternion.identity);
            }
            //destroy this enemy object
            Destroy(this.gameObject);
        }
    }
}
