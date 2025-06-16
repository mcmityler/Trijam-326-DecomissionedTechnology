using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private int _health = 3; //the health of this enemy
    [SerializeField] private GameObject _gearDropObj; //the gear object this thing drops
    [SerializeField] private float _gearDropRate = 3; //can drop up to whatever number this is set to of gears
    [SerializeField] private float _energyGemDropRate = 1.75f; //can drop up to whatever number this is set to of energy gems
    [SerializeField] private GameObject _energyGemDropObj; //the energy gems object this thing drops
    private GameObject _player; //reference to the player
    [SerializeField] private bool _basicMovement = true;
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private int _enemyDamage = 1;
    
    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }

    private void FixedUpdate()
    {
        if (_basicMovement == true)
        {
            MoveEnemy();
        }
    }

    private void MoveEnemy()
    {
        transform.position = Vector3.MoveTowards(this.gameObject.transform.position, _player.transform.position, _moveSpeed *Time.deltaTime);

    }
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
            //GEARS
            int numOfGearsToDrop = Mathf.FloorToInt(Random.Range(0, _gearDropRate)) + 1;
            for (int i = 0; i < numOfGearsToDrop; i++)
            {
                Instantiate(_gearDropObj, this.gameObject.transform.position, Quaternion.identity);
            }
            //ENERGY GEMS
            int numOfEnergyGemsToDrop = Mathf.FloorToInt(Random.Range(0, _energyGemDropRate));
            for (int i = 0; i < numOfEnergyGemsToDrop; i++)
            {
                Instantiate(_energyGemDropObj, this.gameObject.transform.position, Quaternion.identity);
            }
            //destroy this enemy object
            Destroy(this.gameObject);
        }
    }

    public int GetEnemyDamage()
    {
        return _enemyDamage;
    }
}
