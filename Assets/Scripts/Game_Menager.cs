using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Menager : MonoBehaviour {

    public DataHolder data;

    public GameObject tank;
    public GameObject centauro;
    public GameObject stryker;

    public int vehicle_option;
    

	// Use this for initialization
	void Start () {

        data = GameObject.FindObjectOfType<DataHolder>();
        if (data)
        {
            vehicle_option = data.selectedtank;
        }

        switch (vehicle_option)
        {
            case 0:
                stryker.SetActive(true);
                break;
            case 1:
                tank.SetActive(true);
                break;
            case 2:
                centauro.SetActive(true);
                break; 
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
