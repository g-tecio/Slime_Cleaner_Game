using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteMusic : MonoBehaviour
{
    // Start is called before the first frame update
     public GameObject Backgroundmusic;
    public GameObject Backgroundmusicnew;
    void Start()
    {
         Backgroundmusic.SetActive(false);
        Backgroundmusicnew.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
