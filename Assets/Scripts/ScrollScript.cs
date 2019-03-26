using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0;
    public bool vertical;
    public bool raw;
    public Renderer material;
    public RawImage img;
    // Update is called once per frame
    void Update()
    {
        if (raw)
        {
            img.uvRect = new Rect(0, Time.time * speed, 1, 1);
           
        }

        else if (vertical)
        {
            material.material.mainTextureOffset = new Vector2(0, Time.time * speed);
        }
        else
        {
            material.material.mainTextureOffset = new Vector2(Time.time * speed, 0);

        }

    }
}
