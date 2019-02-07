using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    public GameObject @object;
    //public bool dirt;
    GameObject clone;
    public float speedForceDown;
    //public float repeatRate;

    //public bool random = true;
    public float minRange = 2, maxRange = 6;

    // Start is called before the first frame update
    void Awake()
    {
        //Resources search for a folder called Resources
        //if(dirt)
           // @object = Resources.Load<GameObject>("Dirt");
    }

    void Start()
    {
        //if(random)
        Invoke("GenerateThings", Random.Range(minRange, maxRange));
    }

    void GenerateThings()
    {
        clone = Instantiate(@object, transform.position, Quaternion.identity);
        clone.GetComponent<SpriteRenderer>().flipX = Random.value > 0.5f;

        var tempRB = clone.GetComponent<Rigidbody2D>();
        tempRB.AddForce(new Vector2(0, -speedForceDown));

        Invoke("GenerateThings", Random.Range(minRange, maxRange));

        Destroy(clone, 4f);
    }




}
