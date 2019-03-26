using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCollision : MonoBehaviour
{
    public int enemyHealth = 5;
    public Sprite dead;
    public Color deadColor;

    Animator _anim;

    Image img;

    PlayerCollectibles collect;

    void Awake()
    {
        _anim = GetComponent<Animator>();
        img = GetComponent<Image>();
        collect = GameObject.Find("Slime_UI").GetComponent<PlayerCollectibles>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Bullet")
        {
            enemyHealth--;
            Health();
            Destroy(col.gameObject);
        }
    }

    void Health()
    {
        if(enemyHealth <= 0)
        {
            img.color = deadColor;
            img.sprite = dead;
            GameManager.instance.currentScore += 101;
            collect.CheckRecover(101);
            Destroy(GetComponent<CircleCollider2D>());
            _anim.enabled = false;
            Destroy(gameObject, 2f);
        }
    }
}
