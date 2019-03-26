using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public AudioClip[] sfx_hitPlayer;
    public float force = 0.3f;
    public float torque = 150f;
    public float destroyTime = 3f;
    Rigidbody2D rb;
    Color start;
	Color end;
    bool _interpolate;
    float t;

    SpriteRenderer sr;
    AudioSource audioSource;

    PlayerHealth health;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        health = GameObject.Find("LifeBar").GetComponent<PlayerHealth>();

    }

    void Start()
    {
        start = sr.color;
		end = new Color(start.r, start.g, start.b, 0);
        Destroy(gameObject, 3f);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            rb.AddTorque(torque);
            float x = Random.Range(-1000f, 1000f);
            float y = Random.Range(-500f, -1000f);
            rb.AddRelativeForce(new Vector2(x, y) * force);
            Destroy(GetComponent<CapsuleCollider2D>());
            t = 0;
            _interpolate = true;
            audioSource.PlayOneShot(sfx_hitPlayer[Random.Range(0,2)]);
            health.Damage_Health(-1);
        }
    }

    void Update()
    {
        if(_interpolate)
        {
            t += Time.deltaTime;
            sr.color = Color.Lerp(start, end, t*2);
        }
    }
}
