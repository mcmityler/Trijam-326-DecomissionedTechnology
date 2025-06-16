using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 _playerMoveDir = Vector3.zero; //direction player is moving
    [SerializeField] private float _playerMoveSpeed = 1f; //speed player is moving

    private void Update()
    {
        _playerMoveDir = Vector3.zero; //reset player movement
        // move player with wasd or arrows
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            _playerMoveDir += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            _playerMoveDir += Vector3.down;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _playerMoveDir += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _playerMoveDir += Vector3.right;
        }
    }

    private void FixedUpdate()
    {
        //move player towards where they are trying to go 
        if ((_playerMoveDir.x > 0 || _playerMoveDir.x < 0) && (_playerMoveDir.y > 0 || _playerMoveDir.y < 0))
        {

            _playerMoveDir = new Vector3(_playerMoveDir.x / 1.4f, _playerMoveDir.y / 1.4f, 0);
        }
        this.gameObject.transform.position += _playerMoveDir * (Time.deltaTime * _playerMoveSpeed); //put this in the if statement above if i dont want to move while praying

    }

    
}
