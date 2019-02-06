using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{

    public void LoadScene(string sceneName)
    {
        //Debug.Log("mensaje: "+sceneName);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
