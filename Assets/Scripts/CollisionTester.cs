using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Copyright © 2020, Frank Martin
public class CollisionTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with specified collider. CollisionTester is present. Collision" + gameObject.name + " " +  collision.gameObject.name);
    }
}
