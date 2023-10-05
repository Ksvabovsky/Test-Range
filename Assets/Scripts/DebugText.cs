using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DebugText : MonoBehaviour {

    public TMP_Text text;
    Resolution resolution;
    string res;
    string qua;
    string vsync;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        resolution.height = Screen.height;
        resolution.width = Screen.width;
        res = resolution.width + "x" + resolution.height;

        if (QualitySettings.vSyncCount > 0)
        {
            vsync = " VSync on";
        }
        else
        {
            vsync = " VSync off";
        }


        qua = QualitySettings.GetQualityLevel().ToString();
        
        text.text = res + " " + qua+ vsync;
        
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
