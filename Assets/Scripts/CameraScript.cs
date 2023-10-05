using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript: MonoBehaviour {


    #region Components
    DataHolder data;

    [Header("Vehicles")]
    public GameObject B1;
    public GameObject M552;
    public GameObject Stryker;
    public int vehicle_option;

    #endregion

    #region Variables
    private Transform target;
    public Vector3 offset;
    public float speed;
    #endregion

    // Use this for initialization
    void Start () {
        #region Getting Target
        data = GameObject.FindObjectOfType<DataHolder>();
        if (data)
        {
            vehicle_option = data.selectedtank;
        }

        switch (vehicle_option)
        {
            case 0:
                target = Stryker.transform;
                break;
            case 1:
                target = M552.transform;
                break;
            case 2:
                target = B1.transform;
                break;
        }
        #endregion
    }

    // Update is called once per frame
    void FixedUpdate () {
        transform.LookAt(target);

        Vector3 toPos = target.transform.position + offset;
        
        transform.position = Vector3.Lerp(transform.position, toPos, speed * Time.deltaTime );

        
	}
}
