using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading_Script : MonoBehaviour
{
    public Slider loadbar;
    public int sceneindex;

    void Start()
    {
       LoadLevel(sceneindex); 
    }


    public void LoadLevel(int sceneindex)
    {
        StartCoroutine(LoadAsync(sceneindex));
    }

    IEnumerator LoadAsync(int sceneindex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneindex);

        while (!operation.isDone)
        {
            float progress=Mathf.Clamp01(operation.progress/.9f);

            loadbar.value = progress;

            yield return null;
        }
    }
}
