using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Copyright © 2020, Frank Martin
public class DeleteProjectlie : MonoBehaviour
{

    public float lifetime = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifetime * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject otherObject = collision.gameObject;
        Debug.Log("collided with " + otherObject);
        Destroy(gameObject);
    }
}
