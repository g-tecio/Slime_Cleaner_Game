using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroudMove : MonoBehaviour
{
    // Start is called before the first frame update
     public float altura;
     public SpriteRenderer sprite;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        altura= altura * Time.deltaTime;
        sprite.size = new Vector2(sprite.size.x,altura);
    

        
    }
}
