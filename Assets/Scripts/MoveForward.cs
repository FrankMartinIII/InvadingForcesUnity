using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Copyright © 2020, Frank Martin
public class MoveForward : MonoBehaviour
{
    public float speed = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
