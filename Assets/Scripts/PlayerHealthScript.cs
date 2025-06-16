using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{
    [SerializeField] private TMP_Text _playerHealthText;
    [SerializeField] private int _playerHealth = 5;
    [SerializeField] private GameObject _invulnerablilityShield;
    private bool _invulnerable = false;
    private float _invulnerableTime = 2.3f;
    private float _invulnerableCounter = 0;
    private float _flashStartNum = 1.5f;
    private bool _shieldOn = false;

    public void DamagePlayer(int _damageTaken)
    {
        if (_invulnerable == false) // only take damage if not invulnerable
        {
            _playerHealth -= _damageTaken;
            _playerHealthText.text = "health: " + _playerHealth.ToString();
            if (_playerHealth <= 0)
            {
                Debug.Log("Player dead, game over");
            }

            _invulnerablilityShield.SetActive(true);
            _invulnerable = true;
            _shieldOn = true;
        }

    }

    private void Update()
    {
        if (_invulnerable)
        {
            _invulnerableCounter += Time.deltaTime;
            if (_invulnerableCounter > _invulnerableTime)
            {

                _invulnerablilityShield.SetActive(false);
                _invulnerable = false;
                _invulnerableCounter = 0;
                _flashStartNum = 1.5f;

            }
            if (_invulnerableCounter  > _flashStartNum && _invulnerableCounter < (_flashStartNum + 0.1f))
            {
                _invulnerablilityShield.SetActive(!_shieldOn);
                _shieldOn = !_shieldOn;
                _flashStartNum += 0.15f;
            }

        }

    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            DamagePlayer(other.gameObject.GetComponent<EnemyScript>().GetEnemyDamage());
        }
    }

}
