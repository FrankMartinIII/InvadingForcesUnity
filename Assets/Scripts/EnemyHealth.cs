using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Copyright © 2020, Frank Martin
public class EnemyHealth : MonoBehaviour
{
    public int health = 10;
    // Start is called before the first frame update

    public GameObject deathParticles;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Instantiate(deathParticles, transform.position, transform.rotation);
            gameObject.SetActive(false);
            ScoreManager.score += 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject otherObject = collision.gameObject;
        if (otherObject.CompareTag("playerProjectile"))
        {
            PlayerProjectile otherObjectDamage = otherObject.GetComponent<PlayerProjectile>();
            health = health - otherObjectDamage.damageDealt;
        }
    }
}
