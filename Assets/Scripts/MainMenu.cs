using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	
	public void PlayGame ()
    {
        SceneManager.LoadScene("PlayerSelect");
	}

    public void Versus ()
    {
        SceneManager.LoadScene("VersusSelect");
    }
	
    public void QuitGame ()
    {
        Application.Quit();
    }

}
