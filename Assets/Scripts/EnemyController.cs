using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Copyright © 2020, Frank Martin
public class EnemyController : MonoBehaviour
{
    public Transform TargetPoint = null;
    public Transform firePoint = null;

    public float delayBtwnShots = 2.0f;
    protected float shotCounter = 0.0f;


    public float agroDist = 120;
    public float projVelocity = 100.0f;
    public GameObject projectile;

    protected bool isIdle = false;

    protected AudioManager audioManager;

    protected void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void Update()
    {

        if (gameObject.transform.parent.gameObject.GetComponent<FlyerAI>().isActive == true)
        {
            float dist = Vector3.Distance(transform.position, TargetPoint.parent.position);
            //Debug.Log(dist);
            if (Mathf.Abs(dist) < agroDist)
            {
                isIdle = false;
            }
            else
            {
                isIdle = true;
            }

            if (isIdle == false)
            {
                transform.LookAt(TargetPoint);
                if (shotCounter >= delayBtwnShots)
                {
                    /*
                    //GameObject turretShot = Instantiate(projectile, firePoint.transform.position, projectile.rotation) as GameObject;
                    GameObject turretShot = Instantiate(projectile, firePoint.transform.position, Quaternion.identity) as GameObject;
                    //turretShot.AddForce(transform.forward * projVelocity, ForceMode.VelocityChange);
                    turretShot.transform.LookAt(TargetPoint);
                    //turretShot.GetComponent<Rigidbody>().AddForce(turretShot.transform.forward * projVelocity, ForceMode.VelocityChange);
                    Rigidbody shotBody = turretShot.GetComponent<Rigidbody>();
                    shotBody.velocity = turretShot.transform.forward * Time.deltaTime * projVelocity;
                    shotCounter = 0;

                    */
                    audioManager.Play("Shot3");
                    shootProjectile(firePoint);
                }
                else
                {
                    shotCounter += Time.deltaTime;
                }
            }
        }


    }

    protected void shootProjectile(Transform firePoint)
    {
        
        GameObject turretShot = Instantiate(projectile, firePoint.transform.position, Quaternion.identity) as GameObject;
        
        turretShot.transform.LookAt(TargetPoint);
        
        Rigidbody shotBody = turretShot.GetComponent<Rigidbody>();
        shotBody.velocity = turretShot.transform.forward * Time.deltaTime * projVelocity;
        shotCounter = 0;
    }
}
