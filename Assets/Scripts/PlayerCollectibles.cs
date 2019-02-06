using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectibles : MonoBehaviour
{
    public float consumeSpeed;
    CapsuleCollider2D _capsule;
    SpriteRenderer _spriteR;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Collectible")
        {
            _capsule = other.GetComponent<CapsuleCollider2D>();
            _spriteR = other.GetComponent<SpriteRenderer>();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Collectible")
        {
           _capsule.size = new Vector2(_capsule.size.x, _capsule.size.y - consumeSpeed);
           _spriteR.size = new Vector2(_spriteR.size.x, _spriteR.size.y - consumeSpeed);
           GameManager.instance.currentScore++; 
            if(_capsule.size.y <= 0 ||  _spriteR.size.y <= 0)
            {
                Destroy(other.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
