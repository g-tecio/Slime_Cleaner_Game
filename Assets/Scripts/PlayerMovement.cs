using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    RectTransform player;
    Button btnL, btnR, btnM;

    public AudioClip SFX_changeRail;

    //public float xPos = 2.75f;

    Animator _anim;
    bool _end;

    AudioSource _audio;

    void Awake()
    {
        player = GetComponent<RectTransform>();
        btnL = GameObject.Find("Button_Left").GetComponent<Button>();
        btnR = GameObject.Find("Button_Right").GetComponent<Button>();
        btnM = GameObject.Find("Button_Mid").GetComponent<Button>();
        _anim = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
    }

    void Start() { _end = false; }

    public void MidButton()
    {
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


    public void LeftButton()
    {
        _anim.SetInteger("AnimState", -1);
        StartCoroutine(waitAnimation(btnL, "SlimeChangeRailAnimLeft"));
        btnR.enabled = false;
        btnL.enabled = false;
        btnM.enabled = true;
    }


    public void RightButton()
    {
        btnL.enabled = false;
        btnR.enabled = false;
        btnM.enabled = true;
        _anim.SetInteger("AnimState", 1);
        StartCoroutine(waitAnimation(btnR, "SlimeChangeRailRight"));
    }

    IEnumerator waitAnimation(Button btn, string stateName)
    {
        yield return new WaitUntil(() =>
        {
            return _anim.GetCurrentAnimatorStateInfo(0).IsName(stateName)
            && _anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f;
        });
        _anim.SetInteger("AnimState", 0);
        //player.anchoredPosition = new Vector3(btn.transform.position.x, player.anchoredPosition.y, 0);
    }

    IEnumerator waitAnimation(string stateName)
    {
        yield return new WaitUntil(() =>
        {
            return _anim.GetCurrentAnimatorStateInfo(0).IsName(stateName)
            && _anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f;
        });
        _anim.SetInteger("AnimState", 0);
        _end = true;
    }

    public void ChangeRailSound()
    {
        _audio.PlayOneShot(SFX_changeRail);
    }

}
