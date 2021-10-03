using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Serialization;

//Copyright © 2020, Frank Martin
public class FlyerAI : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isActive = false;
    public float speed = 30.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CinemachineDollyCart enemyCart = this.GetComponent<CinemachineDollyCart>();
        if (isActive)
        {
            enemyCart.m_Speed = speed;
        }

    }
}
