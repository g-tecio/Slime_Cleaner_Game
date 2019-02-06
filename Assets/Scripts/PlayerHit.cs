using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public float torque;

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Obstacle")
        {
            var rb = col.gameObject.GetComponent<Rigidbody2D>();
            rb.AddTorque(torque/2);
            rb.AddForce(new Vector2((Random.Range(-5,5)+1), 1) * torque);
            Destroy(col.gameObject.GetComponent<Collider2D>());
            Destroy(col.gameObject, 3f);
        }
    }
}
