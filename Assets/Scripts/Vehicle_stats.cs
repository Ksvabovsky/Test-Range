using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newstats",menuName = "stats")]
public class Vehicle_stats : ScriptableObject {

    public string vehicle_name;
    public int firepower;
    public int reload;
    public int health;
    public int speed;

    public Vector3 CamTransform;

}
