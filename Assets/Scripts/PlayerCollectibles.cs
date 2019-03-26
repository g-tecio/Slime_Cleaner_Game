using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectibles : MonoBehaviour
{
    public float consumeSpeed;
    CapsuleCollider2D _capsule;
    SpriteRenderer _spriteR;

    PlayerHealth _health;

    int _scoreCounter;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Collectible")
        {
            _capsule = other.GetComponent<CapsuleCollider2D>();
            _spriteR = other.GetComponent<SpriteRenderer>();
            _health = GameObject.Find("LifeBar").GetComponent<PlayerHealth>();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Collectible")
        {
            _capsule.size = new Vector2(_capsule.size.x, _capsule.size.y - consumeSpeed);
            _spriteR.size = new Vector2(_spriteR.size.x, _spriteR.size.y - consumeSpeed);
            //Puntuacuacion al archivo scoreText.cs
            GameManager.instance.currentScore+=6;
            CheckRecover(6);
            if (_capsule.size.y <= 0 || _spriteR.size.y <= 0)
            {
                Destroy(other.gameObject);
            }
            
        }
    }

    public void CheckRecover(int x)
    {
        _scoreCounter += x;
        if (_scoreCounter >= 348)
        {
            _scoreCounter = 0;
            _health.Damage_Health(1);
        }
    }
}
