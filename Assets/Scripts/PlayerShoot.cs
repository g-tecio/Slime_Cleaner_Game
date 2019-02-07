using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public float speed;
    public float playerDist;
    Vector3 currentPos;

    public AudioClip sfx_shoot;
    AudioSource audioSource;

    public float shootCD = 0.4f; // CD = Cool Down
    float _shootCD;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        _shootCD = shootCD;
    }

    public void Shoot()
    {
        if (shootCD < 0.4f)
        {
            shootCD = _shootCD;

            currentPos = new Vector3(transform.position.x, transform.position.y + playerDist, transform.position.z);
            var newBullet = Instantiate(bullet, currentPos, Quaternion.identity);

            var bulletRB = newBullet.GetComponent<Rigidbody2D>();
            bulletRB.velocity = new Vector2(0, speed);

            audioSource.PlayOneShot(sfx_shoot);
            Destroy(newBullet, 2f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        shootCD -= Time.deltaTime;
    }
}
