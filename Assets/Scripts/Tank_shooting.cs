using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_shooting : MonoBehaviour {

    public Rigidbody shell;
    public Transform firepoint;
    public float force;

    private float cooldown = 0f ;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

       // Debug.Log(cooldown);
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }

        if ((Input.GetAxis("Fire1")>0) && cooldown <= 0f )
        {
            fire();
            cooldown = 0.5f;
        }
	}

    void fire()
    {
        Rigidbody shellinstance = Instantiate(shell, firepoint.position, firepoint.rotation) as Rigidbody;

        shellinstance.velocity = force * firepoint.forward ;
    }
}
