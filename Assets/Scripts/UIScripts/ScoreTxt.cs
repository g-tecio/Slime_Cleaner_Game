using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTxt : MonoBehaviour
{
    Text txtScore;
    // Start is called before the first frame update
    void Awake()
    {
        txtScore = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        txtScore.text = "Score: "+GameManager.instance.currentScore.ToString();
    }
}
