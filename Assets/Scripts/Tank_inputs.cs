using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_inputs : MonoBehaviour {

    #region Variables
    [Header("Input")]
    public Camera cam;

    public bool mouse;

    public int playernumber;

    public string moveVertical;
    public string moveHorizontal;
    public string turretRotation;

    #endregion

    

    private Vector3 reticlePosition;
    public Vector3 Reticleposition
    {
        get { return reticlePosition;  }
    }

    private Vector3 reticleNormal;
    public Vector3 Reticlenormal
    {
        get { return reticlePosition;  }
    }

    private float forwardInput;
    public float ForwardInput
    {
        get { return forwardInput; }
    }

    private float rotationInput;
    public float RotationInput
    {
        get { return rotationInput; }
    }

    private float turretInput;
    public float TurretInput
    {
        get { return turretInput; }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
            HandleInputs();

	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(reticlePosition, 0.5f);
    }

    #region HandleInputs
    void HandleInputs()
    {
        if (mouse)
        {
            Ray screenray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(screenray, out hit))
            {
                reticlePosition = hit.point;
                reticleNormal = hit.normal;
            }
        }

        forwardInput = Input.GetAxis(moveVertical+playernumber);
        rotationInput = Input.GetAxis(moveHorizontal+playernumber);
        turretInput = Input.GetAxis(turretRotation+playernumber);
        }

    #endregion 
}
