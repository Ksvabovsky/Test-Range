using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Tank_inputs))]
public class Tank_controller : MonoBehaviour {


    [Header("Turret")]
    public Transform turretTransform;
    public float turretspeed;

    [Header("Reticle")]
    public Transform reticleTransform;

    [Header("Shell")]
    public Rigidbody shell;
    public Transform firepoint;
    public float force;

    [Header("Firepower")]
    public float damage;
    public float reloadtime;

    private float cooldown = 0f;
    public float reloading
    {
        get { return cooldown; }
    }

    private Rigidbody rb;
    private Tank_inputs input;
    private Vector3 finalturretlookdir;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
        input = GetComponent<Tank_inputs>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
   
        if (rb && input)
        {
            HandleTurret();
            HandleReticle();
        }

        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }

        if ((Input.GetAxis("Fire1") > 0) && cooldown <= 0f)
        {
            Fire();
            cooldown = reloadtime;
        }

    }

    void HandleTurret()
    {
        if (turretTransform)
        {
            if (input.mouse)
            {
                Vector3 turretlookdir = input.Reticleposition - turretTransform.position;
                turretlookdir.y = 0f;

                finalturretlookdir = Vector3.Lerp(finalturretlookdir, turretlookdir, Time.deltaTime * turretspeed);
                turretTransform.rotation = Quaternion.LookRotation(finalturretlookdir);
            }
            else
            {
                turretTransform.transform.Rotate(0, input.TurretInput * turretspeed*5 * Time.deltaTime, 0);
                Debug.Log(input.TurretInput * turretspeed * Time.deltaTime);
            }
        }

    }

    void HandleReticle ()
    {
        if (reticleTransform)
        {
            reticleTransform.position = input.Reticleposition;
      
        }
    }

    void Fire()
    {
        Rigidbody shellinstance = Instantiate(shell, firepoint.position, firepoint.rotation) as Rigidbody;
        Shell she =shellinstance.GetComponent<Shell>();
        she.damage = damage;
        shellinstance.velocity = force * firepoint.forward;
    }


}
