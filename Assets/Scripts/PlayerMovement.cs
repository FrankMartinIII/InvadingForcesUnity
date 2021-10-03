using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float xySpeed = 18;
    public float lookSpeed = 340;
    public float forwardSpeed = 6;
    public float lookDist = 10.0f;
    public float leanLimit = 80;
    public float timeToLean = 0.1f;

    public Transform aimTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 finalDirection = new Vector3(h, v, lookDist);
        LocalMove(h, v, xySpeed);
        RotationLook(h, v, lookSpeed);
        //RotationLook2(finalDirection, lookSpeed);
        Lean(transform, h, leanLimit, timeToLean);
        ClampPosition();
    }

    void LocalMove(float x, float y , float speed)
    {
        transform.localPosition += new Vector3(x, y, 0) * speed * Time.deltaTime;
    }

    void RotationLook(float h, float v, float speed)
    {
        aimTarget.parent.position = Vector3.zero;
        aimTarget.localPosition = new Vector3(h, v, 1);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(aimTarget.position), Mathf.Deg2Rad * speed *Time.deltaTime);
    }
    
    void RotationLook2(Vector3 direction, float speed)
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), Mathf.Deg2Rad * speed);
    }
    
    void ClampPosition()
    {
        //Viewport space of camera. 0,0 bottom left, 1,1 top right
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    void Lean(Transform target, float axis, float leanLimit, float lerpTime)
    {
        Vector3 targetEulerAngles = target.localEulerAngles;  //represents an objects rotation in the world space.
        Vector3 newRotation = new Vector3(targetEulerAngles.x, targetEulerAngles.y, Mathf.LerpAngle(targetEulerAngles.z, -axis * leanLimit, lerpTime));
        target.localEulerAngles = newRotation;
    }
}
