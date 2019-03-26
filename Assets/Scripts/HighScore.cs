using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighScore : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Score1;
    void Start()
    {
        GameManager.instance.highScore= PlayerPrefs.GetFloat("Puntuacion",GameManager.instance.highScore);
        Score1.text = ""+GameManager.instance.highScore.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
