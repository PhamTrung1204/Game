using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponAttribute : MonoBehaviour
{
    public AttributesManager atm;
    private AudioManager audioManager;
    public int damageAmount = 20;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(transform.GetComponent<Rigidbody>());

        if (other.tag == "Enemy" && PlayerCombat.isAttacking)
        {
            other.GetComponent<AttributesManager>().TakeDamage(atm.attack);
            audioManager.PlaySFX(audioManager.enemyImpact);
            other.GetComponent<Dragon>().TakeDamage(damageAmount);
        }    
    }
}
