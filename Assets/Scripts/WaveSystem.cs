using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveSystem : MonoBehaviour
{
    [SerializeField] private GameObject _basicRobot; //basic Robot enemy that just moves towards you. 
    [SerializeField] private GameObject[] _spawnLocations;


    private void Start()
    {
        SpawnEnemy(_basicRobot);
        SpawnEnemy(_basicRobot);
        SpawnEnemy(_basicRobot);
        SpawnEnemy(_basicRobot);
        SpawnEnemy(_basicRobot);
    }

    private void SpawnEnemy(GameObject _spawnEnemyType)
    {
        int _spawnLocationNum = Mathf.RoundToInt(Random.Range(0, _spawnLocations.Length));
        Instantiate(_spawnEnemyType, RandomizeSpawnPosition(_spawnLocations[_spawnLocationNum]), Quaternion.identity);
    }
    private Vector3 RandomizeSpawnPosition(GameObject m_spawnBoundary)
    {
        var m_randx = Random.Range(m_spawnBoundary.transform.position.x- m_spawnBoundary.transform.localScale.x/2,
            m_spawnBoundary.transform.position.x + m_spawnBoundary.transform.localScale.x/2); //random x position
            
        var m_randy = Random.Range(m_spawnBoundary.transform.position.y- m_spawnBoundary.transform.localScale.y/2,
            m_spawnBoundary.transform.position.y + m_spawnBoundary.transform.localScale.y/2); //random y position
            
        return new Vector3(m_randx, m_randy, 0f);
    }
}
