using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Rigidbody[] bullet = new Rigidbody[1];
    public float velocity = 100.0f;
    public int weaponLevel = 0;

    private AudioManager audioManager;

    private Transform playerPos;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            //Rigidbody newBullet = Instantiate(bullet[weaponLevel], transform.position, bullet[weaponLevel].rotation) as Rigidbody;
            Rigidbody newBullet = Instantiate(bullet[weaponLevel], transform.position, playerPos.rotation) as Rigidbody;
            newBullet.AddForce(transform.forward * velocity, ForceMode.VelocityChange);
            //ScoreManager.score += 1; 
            audioManager.Play("PLaserShot");
        }
    }
}
