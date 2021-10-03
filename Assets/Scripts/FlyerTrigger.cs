using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Copyright © 2020, Frank Martin
public class FlyerTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision");
        GameObject collided = other.gameObject;
        
        if (collided.CompareTag("Player"))
        {
            Debug.Log("Collision with Player");
            FlyerAI aiScript = transform.parent.gameObject.GetComponent<FlyerAI>();
            aiScript.isActive = true;
            gameObject.SetActive(false);
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("THERE WAS A COLLISION");
    }
    */


}
