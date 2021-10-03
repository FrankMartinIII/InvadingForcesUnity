using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Copyright © 2020, Frank Martin
public class TwinBlastEnemyController : EnemyController
{
    public Transform firePoint2 = null;

    // Update is called once per frame
    private void Update()
    {

        if (gameObject.transform.parent.gameObject.GetComponent<FlyerAI>().isActive == true)
        {
            float dist = Vector3.Distance(transform.position, TargetPoint.position);
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
                    audioManager.Play("Shot2");
                    shootProjectile(firePoint);
                    shootProjectile(firePoint2);
                }
                else
                {
                    shotCounter += Time.deltaTime;
                }
            }
        }


    }
}
