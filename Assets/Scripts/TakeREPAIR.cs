using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeREPAIR : MonoBehaviour
{
    public int healthBoostAmount = 50; 
    public Damagable tankDamagable;
    public AudioSource SupplyAudio;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (tankDamagable != null)
            {
                SupplyAudio.Play();
                tankDamagable.Heal(healthBoostAmount);
                Destroy(gameObject);
            }
        }
    }
}