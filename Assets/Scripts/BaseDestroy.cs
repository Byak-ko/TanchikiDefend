using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDestroy : MonoBehaviour
{
    public GameObject Canvas;

    private GameObject _hud;

    private void Start()
    {

        _hud = GameObject.Find("Player HUD");
    }

    public void uiShow()
    {
        if (_hud != null)
        {

            _hud.SetActive(false);
        }


        Canvas.SetActive(true);


        Time.timeScale = 0f;
    }
}
