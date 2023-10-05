using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class Vehicle_select : MonoBehaviour {

    public List<Vehicle_stats> vehicle = new List<Vehicle_stats>();

    public Vehicle_stats stryker;
    public Vehicle_stats tank;
    public Vehicle_stats centauro;

    public DataHolder data;
    public bool tankp1;
    public bool tankp2;

    public Camera cam;
    public int activeoption;
    public float camspeed;
    public Vector3 camoffset;

    #region UI_elements

    public TMP_Text vehicleName;

    public Slider firepowerSlider;
    public TMP_Text firepowerText;

    public Slider reloadSlider;
    public TMP_Text reloadText;

    public Slider healthSlider;
    public TMP_Text healthText;

    public Slider speedSlider;
    public TMP_Text speedText;


    #endregion


    // Use this for initialization
    void Start () {
        vehicle.Add(stryker);
        vehicle.Add(tank);
        vehicle.Add(centauro);

        activeoption = 0;
        UpdateUi();

        data = GameObject.FindObjectOfType<DataHolder>();

    }
	
	// Update is called once per frame
	void UpdateUi () {
        vehicleName.text = vehicle[activeoption].vehicle_name;

        firepowerSlider.value = vehicle[activeoption].firepower;
        firepowerText.text = vehicle[activeoption].firepower.ToString();

        reloadSlider.value = vehicle[activeoption].reload;
        reloadText.text = vehicle[activeoption].reload.ToString();

        healthSlider.value = vehicle[activeoption].health;
        healthText.text = vehicle[activeoption].health.ToString();

        speedSlider.value = vehicle[activeoption].speed;
        speedText.text = vehicle[activeoption].speed.ToString();

        //cam.transform.position = vehicle[activeoption].CamTransform;
    }

    void FixedUpdate()
    {
        Vector3 campos = cam.transform.position;
        cam.transform.position = Vector3.Slerp(campos,vehicle[activeoption].CamTransform + camoffset,Time.deltaTime *camspeed );
    }

    public void nextOption()
    {
        if (activeoption < 2)
        {
            activeoption++;
            UpdateUi();
            //moveCam();
        }
    }

    public void previousOption()
    {
        if (activeoption > 0)
        {
            activeoption--;
            UpdateUi();
            //moveCam();
        }
    }
    public void deploy()
    {
        data.selectedtank = activeoption;
        if (tankp1 == true)
        {
            data.tankP1 = activeoption;
        }
        if(tankp2 == true)
        {
            data.tankP2 = activeoption;
        }
        
        SceneManager.LoadScene("Range");
    }
}
