using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Copyright © 2020, Frank Martin
public class ChangeEnemySpeed : MonoBehaviour
{
    protected FlyerAI aiScript;
    // Start is called before the first frame update
    void Start()
    {
        aiScript = gameObject.GetComponentInParent<FlyerAI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("enemySpeedChange"))
        {
            Debug.Log("Enemy Speed should be changing");
            float newSpeed = collision.gameObject.GetComponent<EnemySpeedChangeObject>().newSpeed;
            aiScript.speed = newSpeed;

        }
    }
}
