using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Tank_inputs))]
public class Tank_Tracks : MonoBehaviour {

    public float tankspeed = 15f;
    public float tankRotationSpeed = 10f;

    private Rigidbody rb;
    private Tank_inputs input;
    
    void Start () {

        rb = GetComponent<Rigidbody>();
        input = GetComponent<Tank_inputs>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (rb && input)
        {
            HandleMovement();
        }
    }

    void HandleMovement()
    {
        Vector3 wantedpositon = transform.position + (transform.forward * input.ForwardInput * tankspeed * Time.deltaTime);
        rb.MovePosition(wantedpositon);

        Quaternion wantedRotation = transform.rotation * Quaternion.Euler(Vector3.up * input.RotationInput * tankRotationSpeed * Time.deltaTime);
        rb.MoveRotation(wantedRotation);
    }
}
