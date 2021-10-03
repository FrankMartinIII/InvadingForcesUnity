using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Copyright © 2020, Frank Martin
public class Pillar : MonoBehaviour
{
    //private GameObject collisionBox;
    private Animator anim;
    public GameObject playerRef;
    private Transform playerPos;
    public float fallDist = 100;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //collisionBox = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        //playerPos = playerRef.transform;
        if (Mathf.Abs(Vector3.Distance(transform.position, playerRef.transform.position)) < fallDist)
        {
            anim.SetTrigger("Make Pillar Fall");
        }
    }
}
