using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public float speed;
    public float playerDist;
    Vector3 currentPos;

    public void Shoot()
    {
        currentPos = new Vector3(transform.position.x, transform.position.y + playerDist, transform.position.z);
        var newBullet = Instantiate(bullet, currentPos, Quaternion.identity);
        var bulletRB = newBullet.GetComponent<Rigidbody2D>();
        bulletRB.velocity = new Vector2(0, speed);
        Destroy(newBullet, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
