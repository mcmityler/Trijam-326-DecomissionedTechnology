using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingScript : MonoBehaviour
{
    [SerializeField] private GameObject _bulletSpawnPointObj; //Where the bullet spawns from
    [SerializeField] private float _bulletSpeed = 3; //the speed the bullet travels when it spawns
    [SerializeField] private GameObject _bullet; //the object of the bullet to spawn
    [SerializeField] private float _bulletDestroyTime = 2f; //the time that the bullet is destroyed after it is spawned.

    private void Update()
    {
        Vector3 mouseScreen = Input.mousePosition; //get the position of the mouse on the screen
        Vector3 mouse = Camera.main.ScreenToWorldPoint(mouseScreen); //convert mouse screen point to vector on camera 

        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg - 90); //rotate the player towards the mouse for shooting
        
        if (Input.GetMouseButton(0)) //if the player presses the left mouse button spawn a bullet
        {
            SpawnBullet(); //spawn a bullet
        }
    }

    private void SpawnBullet() //spawn a bullet 
    {
        GameObject m_bullet = Instantiate(_bullet, _bulletSpawnPointObj.transform.position, Quaternion.identity); //spawn a bullet at the bullet spawn point on player
        m_bullet.transform.up = _bulletSpawnPointObj.transform.up; //make the bullet face where it is shooting 
        BulletScript bulletScript = m_bullet.GetComponent<BulletScript>(); //get bullet script from bullet 
        bulletScript.SetMoveSpeed(_bulletSpeed); //set bullet speed
        bulletScript.SetBulletDestroyTime(_bulletDestroyTime); //set when bullet will be destroyed
    }
}
