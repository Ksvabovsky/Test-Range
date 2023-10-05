using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder: MonoBehaviour {

    public int selectedtank;
    public int tankP1;
    public int tankP2;

    public bool mouse;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

   /* private void Update()
    {
        if (Input.GetJoystickNames() != null)
        {
            Debug.Log("pad");
            Debug.Log(Input.GetJoystickNames()[0]);
            mouse = false;
        }
        else
        {
            Debug.Log("mouse");
            mouse = true;
        }
    }
    */

}
