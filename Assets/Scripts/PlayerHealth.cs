using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    Image lifeBar;
    public float health = 4;

    /// <summary>
    /// Health 0 = full;
    /// </summary>
    public Sprite[] sprites;

    Animator _anim;
    PlayerMovement _movement;
    PlayerShoot _shoot;
    float _animSpeed;

    bool _hit = false;

    void Awake()
    {
        lifeBar = GetComponent<Image>();
        var player = GameObject.Find("Slime_UI").GetComponent<Animator>();
        _anim = player.GetComponent<Animator>();
        _shoot = player.GetComponent<PlayerShoot>();
        _movement = player.GetComponent<PlayerMovement>();
    }

    void Start()
    {
        _hit = false;
        _animSpeed = _anim.speed;
    }

    public void Damage_Health(int value)
    {
        health += value;

        if (health >= 4)
        {
            lifeBar.sprite = sprites[0];
            health = 4;
        }
        else if (health == 3)
        {
            lifeBar.sprite = sprites[1];
        }
        else if (health == 2)
        {
            lifeBar.sprite = sprites[2];
        }
        else if (health == 1)
        {
            lifeBar.sprite = sprites[3];
        }
        else if (health == 0)
        {
            lifeBar.sprite = sprites[4];
        }

        if (health == 0)
        {
            PlayerDead();
        }
        else
        {
            PlayerHit();
        }
    }

    void PlayerDead()
    {
        _anim.SetInteger("AnimState", -6);
        _movement.enabled = false;
        _shoot.enabled = false;
        //_anim.enabled = false;
    }

    void PlayerHit()
    {
        _anim.SetInteger("AnimState", -5);
        StartCoroutine(waitAnimation("Slime_HitAnim"));
    }


    IEnumerator waitAnimation(string stateName)
    {
        _hit = true;
        yield return new WaitUntil(() =>
        {
            return _anim.GetCurrentAnimatorStateInfo(0).IsName(stateName)
            && _anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f;
        });
        _hit = false;
        _anim.SetInteger("AnimState", 0);
    }
}
