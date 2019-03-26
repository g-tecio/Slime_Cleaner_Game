using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    RectTransform player;
    public Button btnL, btnR, btnM;

    public AudioClip SFX_changeRail;

    //public float xPos = 2.75f;

    Animator _anim;

    AudioSource _audio;

    PlayerHealth _health;

    float currentTime;

    void Awake()
    {
        player = GetComponent<RectTransform>();
        btnL = GameObject.Find("Button_Left").GetComponent<Button>();
        btnR = GameObject.Find("Button_Right").GetComponent<Button>();
        btnM = GameObject.Find("Button_Mid").GetComponent<Button>();
        _anim = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
        _health = GameObject.FindObjectOfType<PlayerHealth>();
    }

    public void DisableButtons()
    {
        btnR.enabled = false;
        btnL.enabled = false;
        btnM.enabled = false;
        var btnPlayer = GetComponent<Button>();
        btnPlayer.interactable = false;
    }

    public void EnableButtons()
    {
        btnR.enabled = true;
        btnL.enabled = true;
        btnM.enabled = true;
        var btnPlayer = GetComponent<Button>();
        btnPlayer.interactable = true;
    }

    public void MidButton()
    {
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("SlimeIdle"))
        {
            gameObject.layer = 12;
            if (0 < player.position.x)
            {
                _anim.SetInteger("AnimState", 2);
                StartCoroutine(waitAnimation("ISlimeChangeRailRight"));
            }
            else if (0 > player.position.x)
            {
                _anim.SetInteger("AnimState", -2);
                StartCoroutine(waitAnimation("ISlimeChangeRailAnimLeft"));
            }
            btnR.enabled = true;
            btnL.enabled = true;
            btnM.enabled = false;
        }

    }

    public void ChangeState(int state)
    {
        _anim.SetInteger("AnimState", state);
        if (!_health.inHit)
            gameObject.layer = 8;
    }


    public void LeftButton()
    {
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("SlimeIdle"))
        {
            gameObject.layer = 12;
            _anim.SetInteger("AnimState", -1);
            StartCoroutine(waitAnimation("SlimeChangeRailAnimLeft"));
            btnR.enabled = false;
            btnL.enabled = false;
            btnM.enabled = true;
        }
    }


    public void RightButton()
    {
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("SlimeIdle"))
        {
            gameObject.layer = 12;
            btnL.enabled = false;
            btnR.enabled = false;
            btnM.enabled = true;
            _anim.SetInteger("AnimState", 1);
            StartCoroutine(waitAnimation("SlimeChangeRailRight"));
        }
    }

    void Update() { currentTime += Time.deltaTime; }

    IEnumerator waitAnimation(string stateName)
    {
        currentTime = 0;
        yield return new WaitUntil(() =>
        {
            return _anim.GetCurrentAnimatorStateInfo(0).IsName(stateName)
            && _anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= .9f || currentTime > .8f;
        });
        _anim.SetInteger("AnimState", 0);
        if (!_health.inHit)
        {
            gameObject.layer = 8;
        }
    }

    public void ChangeRailSound()
    {
        _audio.PlayOneShot(SFX_changeRail);
    }
}
