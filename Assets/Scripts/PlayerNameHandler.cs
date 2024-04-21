using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerNameHandler : MonoBehaviour
{
    public TextMeshProUGUI PlayerName;

    private void Start()
    {
        PlayerName.text = SystemInfo.deviceName;
    }
}
