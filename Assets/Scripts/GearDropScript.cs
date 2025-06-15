using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GearDropScript : MonoBehaviour
{
    
    [SerializeField]private float _randomTravelSpeed; //random speed this travels when dropped to disperse them
    [SerializeField]private Vector3 _randomDirection = Vector3.zero;//random direction this travels when dropped to disperse them
    [SerializeField] private int _gearValue = 1; //value of gear when collected by player
     
    // Start is called before the first frame update
    private void Start()
    {
        //get a random direction for gear to travel in 
        _randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
        _randomTravelSpeed = Random.Range(1f,3f);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (_randomTravelSpeed >= 0.01f)
        {
            gameObject.transform.position += _randomDirection * (_randomTravelSpeed * Time.deltaTime);
           _randomTravelSpeed *= 0.85f; 
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //add to players gear collection
            other.gameObject.GetComponent<PlayerWealthScript>().CollectGear(_gearValue);
            Destroy(this.gameObject);

        }
    }
}
