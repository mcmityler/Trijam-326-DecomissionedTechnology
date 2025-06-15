using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private Vector3 _moveDir; //direction the bullet moves

    [SerializeField] private float _bulletMoveSpeed; //speed of the bullet
    [SerializeField] private int _bulletDamage; //how much damage the bullet deals

    // Start is called before the first frame update
    private void Start()
    {
        _moveDir = this.gameObject.transform.up;
    }

    // Update is called once per frame
    private void Update()
    {
        this.gameObject.transform.position += _moveDir * (_bulletMoveSpeed * Time.deltaTime);
    }

    public void SetMoveSpeed(float m_bulletmoveSpeed)
    {
        _bulletMoveSpeed = m_bulletmoveSpeed;
    }

    public void SetBulletDestroyTime(float m_destroyTime)
    {
        Destroy(this.gameObject, m_destroyTime);
    }

    public void SetBulletDamage(int m_bulletDamage)
    {
        _bulletDamage = m_bulletDamage;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyScript>().InflictDamage(_bulletDamage);
            Destroy(this.gameObject);
        }
    }
}