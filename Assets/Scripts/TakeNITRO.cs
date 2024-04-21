using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeNITRO : MonoBehaviour
{
    public AudioSource SupplyAudio;

    public TankMover tank;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            tank.ActivateBoost();       
            Destroy(gameObject);
            SupplyAudio.Play();

        }
    }
}
