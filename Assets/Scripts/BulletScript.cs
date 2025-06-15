using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private Vector3 _moveDir;

    [SerializeField] private float _bulletmoveSpeed;

    // Start is called before the first frame update
    private void Start()
    {
        _moveDir = this.gameObject.transform.up;
    }

    // Update is called once per frame
    private void Update()
    {
        this.gameObject.transform.position += _moveDir * (_bulletmoveSpeed * Time.deltaTime);
    }

    public void SetMoveSpeed(float m_bulletmoveSpeed)
    {
        _bulletmoveSpeed = m_bulletmoveSpeed;
    }

    public void SetBulletDestroyTime(float m_destroyTime)
    {
        Destroy(this.gameObject, m_destroyTime);
    }
}