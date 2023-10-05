using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_HUD : MonoBehaviour
{
    #region Components
    DataHolder data;

    [Header("Vehicles")]
    public GameObject B1;
    public GameObject M552;
    public GameObject Stryker;
    public int vehicle_option;

    private GameObject tank;
    Tank_controller tank_con;
    Health_Script tank_health;
    #endregion

    #region UI Elements
    [Header("UI Elements")]
    public TMP_Text healthtext;
    public TMP_Text reloadtext;
    public Slider healthbar;
    public Slider reloadbar;
    public Image healthfill;
    public Image reloadfill;
    #endregion

    #region Colors
    [Header("UI Colors")]
    public Color readyCol;
    public Color unreadyCol;
    private Color healthCol;
    #endregion

    #region Variables
    float Maxhealth;
    float currenthealth;
    float reload;
    float reloadtime;
    #endregion

    void Start()
    {
        #region Getting Variables
        data = GameObject.FindObjectOfType<DataHolder>();
        if (data)
        {
            vehicle_option = data.selectedtank;
        }

        switch (vehicle_option)
        {
            case 0:
                tank=Stryker;
                break;
            case 1:
                tank=M552;
                break;
            case 2:
                tank=B1;
                break;
        }

        tank_con = tank.GetComponent<Tank_controller>();
        tank_health = tank.GetComponent<Health_Script>();
        Maxhealth = tank_health.startingHealth;
        healthbar.maxValue = Maxhealth;
        reloadtime = tank_con.reloadtime;
        reloadbar.maxValue = reloadtime;
        #endregion
    }

    void FixedUpdate()
    {
        #region Health
        currenthealth = tank_health.CurrentHealth;
        healthbar.value = currenthealth;
        healthCol = Color.Lerp(unreadyCol, readyCol, currenthealth / currenthealth);
        healthfill.color = healthCol;
        healthtext.color = healthCol;
        #endregion

        #region Reload
        reload = tank_con.reloading;
        reloadbar.value = reloadtime - reload;
        if (reload <= 0) {
            reloadfill.color = readyCol;
            reloadtext.color = readyCol;
            reloadtext.text = reloadtime.ToString();
        }
        else
        {
            reloadfill.color = unreadyCol;
            reloadtext.color = unreadyCol;
            reload = Mathf.Round(reload * 10) / 10;
            reloadtext.text = reload.ToString();
        }
        #endregion  
    }
}
