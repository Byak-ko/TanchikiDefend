using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyCountDestroy : MonoBehaviour
{
    public float TankDestroyDelay = 3;

    private Damagable _health;
    private GameObject _destroyedEnemyCounter;
    private DestroyedEnemyCounter _counter;
    
    private void Start()
    {
        _destroyedEnemyCounter = GameObject.Find("EnemyCounter");
        _counter = _destroyedEnemyCounter.GetComponent<DestroyedEnemyCounter>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("LightTank"))
        {
            _health = other.gameObject.GetComponent<Damagable>();
            if (_health.Health <= 0)
            {
                _counter.Enemy += 1;
            }
        }
    
        if (other.gameObject.CompareTag("HeavyTank"))
        {
                _health = other.gameObject.GetComponent<Damagable>();
                if (_health.Health <= 0)
                {
                    _counter.BigEnemy += 1;
            }
        }

        /*if (other == GameObject.Find("Player") || other == GameObject.Find("Base"))
        {
            _health = other.gameObject.GetComponent<Damagable>();
            if (_health.Health <= 0)
            {
                _hud = GameObject.Find("Player HUD");
                _hud.SetActive(false);
                Canvas.SetActive(true);
            }
        }*/

       

        CheckMaxDestroyed();
    }

    public void CheckMaxDestroyed()
    {
        int sum = _counter.Enemy  + _counter.BigEnemy;
        Debug.Log("CheckDestroyed");
        if (sum > PlayerPrefs.GetInt("MaxDestroyedTanks", 0)) {
            PlayerPrefs.SetInt("MaxDestroyedTanks", sum);
        }
        
        PlayerPrefs.Save();
    }

  
    
}
