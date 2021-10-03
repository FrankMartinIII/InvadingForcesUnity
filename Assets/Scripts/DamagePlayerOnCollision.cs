using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Copyright © 2020, Frank Martin
public class DamagePlayerOnCollision : MonoBehaviour
{

    public float damageCooldown = 1.0f;

    private bool inCooldown = false;
    private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject otherObject = collision.gameObject;
        if (otherObject.CompareTag("enemyProjectile") && inCooldown == false)
        {
            float valueToDamagePlayer = otherObject.GetComponent<DamageValue>().damageValue;
            HealthManager.damagePlayer(valueToDamagePlayer);
            inCooldown = true;
            Invoke("Uncool", damageCooldown);
        }
        /*
        else if (otherObject.CompareTag("terrain") && inCooldown == false)
        {
            //float valueToDamagePlayer = otherObject.GetComponent<DamageValue>().damageValue;
            HealthManager.damagePlayer(20);
            inCooldown = true;
            Invoke("Uncool", damageCooldown);
        }*/
        else if (otherObject.CompareTag("enemy") && inCooldown == false)
        {
            //float valueToDamagePlayer = otherObject.GetComponent<DamageValue>().damageValue;
            HealthManager.damagePlayer(20);
            inCooldown = true;
            Invoke("Uncool", damageCooldown);
        }

        else if (otherObject.CompareTag("healthRestore"))
        {
            //float valueToDamagePlayer = otherObject.GetComponent<DamageValue>().damageValue;
            otherObject.SetActive(false);
            HealthManager.healPlayer(20);
            audioManager.Play("Whir");
        }

        else if (otherObject.CompareTag("laserPowerUp"))
        {
            //float valueToDamagePlayer = otherObject.GetComponent<DamageValue>().damageValue;
            PlayerShoot[] playerCanonFire = GetComponentsInChildren<PlayerShoot>();
            otherObject.SetActive(false);
            foreach (PlayerShoot canon in playerCanonFire)
            {
                if (canon.weaponLevel < canon.bullet.Length)
                {
                    canon.weaponLevel++;
                    audioManager.Play("Whir");
                }
            }
            
        }
    }

    private void OnCollisionStay(Collision collision) //once per frame
    {
        GameObject otherObject = collision.gameObject;
        if (otherObject.CompareTag("terrain") && inCooldown == false)
        {
            //float valueToDamagePlayer = otherObject.GetComponent<DamageValue>().damageValue;
            HealthManager.damagePlayer(20);
            inCooldown = true;
            Invoke("Uncool", damageCooldown);
        }

    }



    void Uncool()
    {
        inCooldown = false;
    }
}
