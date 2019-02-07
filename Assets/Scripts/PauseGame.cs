using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    // Start is called before the first frame update
    public  void Pause(){
      Time.timeScale= 0;
    }
    public void ResumeGame(){
         Time.timeScale= 1;
     }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
