using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetDestroyed : MonoBehaviour
{
    public TextMeshProUGUI LightTanks;
    public TextMeshProUGUI HeavyTanks;

    private GameObject _counter;
    private DestroyedEnemyCounter _inst;

    private void Start()
    {
        _counter = GameObject.Find("EnemyCounter");
        _inst = _counter.GetComponent<DestroyedEnemyCounter>();

        int newVal1 = _inst.Enemy; 
        int newVal2 = _inst.BigEnemy;

        LightTanks.text = newVal1.ToString();
        HeavyTanks.text = newVal2.ToString();
    }
}
