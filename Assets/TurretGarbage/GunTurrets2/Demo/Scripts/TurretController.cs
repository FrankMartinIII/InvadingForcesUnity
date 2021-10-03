using UnityEngine;

namespace GT2.Demo
{
    public class TurretController : MonoBehaviour
    {
        [SerializeField] private TurretAim TurretAim = null;

        public Transform TargetPoint = null;
        public Transform firePoint = null;

        public float delayBtwnShots = 2.0f;
        private float shotCounter = 0.0f;


        public float agroDist = 120;
        public float projVelocity = 100.0f;
        public GameObject projectile;

        private bool isIdle = false;
        private AudioManager audioManager;

        private void Awake()
        {
            audioManager = FindObjectOfType<AudioManager>();
            if (TurretAim == null)
                Debug.LogError(name + ": TurretController not assigned a TurretAim!");
        }

        private void Update()
        {
            if (TurretAim == null)
                return;

            if (TargetPoint == null)
                TurretAim.IsIdle = TargetPoint == null;
            else
                TurretAim.AimPosition = TargetPoint.position;
            float dist = Vector3.Distance(transform.position, TargetPoint.parent.position);
            //Debug.Log(dist);
            if (Mathf.Abs(dist) < agroDist) 
            {
                TurretAim.IsIdle = false;
            }
            else
            {
                TurretAim.IsIdle = true;
            }

            if (TurretAim.IsIdle == false && TurretAim.IsAimed == true)
            {
                if (shotCounter >= delayBtwnShots)
                {
                    //GameObject turretShot = Instantiate(projectile, firePoint.transform.position, projectile.rotation) as GameObject;
                    GameObject turretShot = Instantiate(projectile, firePoint.transform.position, Quaternion.identity) as GameObject;
                    //turretShot.AddForce(transform.forward * projVelocity, ForceMode.VelocityChange);
                    turretShot.transform.LookAt(TargetPoint);
                    //turretShot.GetComponent<Rigidbody>().AddForce(turretShot.transform.forward * projVelocity, ForceMode.VelocityChange);
                    Rigidbody shotBody = turretShot.GetComponent<Rigidbody>();
                    shotBody.velocity = turretShot.transform.forward * Time.deltaTime * projVelocity;
                    audioManager.Play("Shot1");
                    shotCounter = 0;
                }
                else
                {
                    shotCounter += Time.deltaTime;
                }
            }

            
        }
    }
}
