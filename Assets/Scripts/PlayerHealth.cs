using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    Image lifeBar;
    public float flashTime;
    public float health = 4;
    public bool GameOver;
    public GameObject Panelgameover;
    public GameObject Backgroundmusic;
    public GameObject Backgroundmusicnew;
    public float highScoreview;

    public GameObject enablebtnpasue;
    /// <summary>
    /// Health 0 = full;
    /// </summary>
    public Sprite[] sprites;

    Animator _anim;
    PlayerMovement _movement;
    Image _sr;

    GameObject player;

    float currentTime;

    public bool inHit;

    void Awake()
    {
        lifeBar = GetComponent<Image>();
        player = GameObject.Find("Slime_UI");
        _anim = player.GetComponent<Animator>();
        _movement = player.GetComponent<PlayerMovement>();
        _sr = player.GetComponent<Image>();
    }

    void Start()
    {
        ResumeGame();
        GameManager.instance.currentScore = 0;
        GameManager.instance.highScore = PlayerPrefs.GetFloat("Puntuacion", GameManager.instance.highScore);
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
        if (health <= 0)
        {
            enablebtnpasue.SetActive(false);
            PlayerDead();
            if (GameOver)
            {
                StartCoroutine(waitTime());
                PlayerPrefs.SetFloat("Puntuacion", GameManager.instance.highScore);


                if (GameManager.instance.currentScore > GameManager.instance.highScore)
                {

                    GameManager.instance.highScore = GameManager.instance.currentScore;
                    GameManager.instance.currentScore = 0;

                    PlayerPrefs.SetFloat("Puntuacion", GameManager.instance.highScore);
                    highScoreview = PlayerPrefs.GetFloat("Puntuacion", GameManager.instance.highScore);
                    GameManager.instance.highScore = highScoreview;
                }


            }

        }
        else if(value < 0)
        {
            PlayerHit();
        }
    }

    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(2f);
        Pause();
        Panelgameover.SetActive(true);
        Backgroundmusic.SetActive(false);
        Backgroundmusicnew.SetActive(true);

        var obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (var item in obstacles)
        {
            if (item != null)
                item.SetActive(false);
        }

        var collectibles = GameObject.FindGameObjectsWithTag("Collectible");
        foreach (var item in collectibles)
        {
            if (item != null)
                item.SetActive(false);
        }

        var bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (var item in bullets)
        {
            if (item != null)
                item.SetActive(false);
        }

        _anim.gameObject.SetActive(false);
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    void PlayerDead()
    {
        _anim.SetInteger("AnimState", -6);
        _movement.DisableButtons();
        GameOver = true;
    }

    void PlayerHit()
    {
/*         if(_anim.GetCurrentAnimatorStateInfo(0).IsName("ISlimeChangeRailAnimLeft")
        || _anim.GetCurrentAnimatorStateInfo(0).IsName("ISlimeChangeRailRight")
        || _anim.GetCurrentAnimatorStateInfo(0).IsName("SlimeChangeRailAnimLeft")
        || _anim.GetCurrentAnimatorStateInfo(0).IsName("SlimeChangeRailRight"))
        {
            return;
        } */
        _anim.SetInteger("AnimState", -5);
        Invisible();
        player.layer = 12;
        inHit = true;
        //_movement.DisableButtons();
        StartCoroutine(waitAnimation("Slime_HitAnim"));
    }

    void Invisible()
    {
        _sr.color = new Color(_sr.color.r, _sr.color.g, _sr.color.b, 0);
        Invoke("Visible", flashTime);
    }

    void Visible()
    {
        _sr.color = new Color(_sr.color.r, _sr.color.g, _sr.color.b, 1);
        Invoke("Invisible", flashTime);
    }

    void Update() { currentTime += Time.deltaTime;}

    IEnumerator waitAnimation(string stateName)
    {
        currentTime = 0;
        yield return new WaitUntil(() =>
        {
            return _anim.GetCurrentAnimatorStateInfo(0).IsName(stateName)
            && _anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= .1f || currentTime > 1.5f;
        });
        _anim.SetInteger("AnimState", 0);
        //_movement.EnableButtons();
        Invoke("Cancel", 2f);
    }



    void Cancel()
    {
        _sr.color = new Color(_sr.color.r, _sr.color.g, _sr.color.b, 1);
        player.layer = 8;
        inHit = false;
        CancelInvoke("Visible");
        CancelInvoke("Invisible");
        CancelInvoke();
    }
}
