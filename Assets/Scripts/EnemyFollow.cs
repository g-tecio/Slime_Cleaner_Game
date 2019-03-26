using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFollow : MonoBehaviour
{
    public float downSpeed = 2;
    RectTransform enemy, previousPos;
    Button btnL, btnM, btnR;
    Animator _anim;

    int num;

    EnemyShoot shootCs;
    EnemyCollision col;

    // Start is called before the first frame update
    void Awake()
    {
        enemy = GetComponent<RectTransform>();
        _anim = GetComponent<Animator>();

        shootCs = GetComponent<EnemyShoot>();
        col = GetComponent<EnemyCollision>();
    }

    void Start()
    {
        Invoke("ChangePosition", 1.5f);
    }


    void ShootPlayer()
    {
        shootCs.Shoot();
    }

    void ChangePosition()
    {
        num = Random.Range(0, 2) * 2 - 1;
        _anim.SetInteger("AnimState", num);
        StartCoroutine(waitAnimation());

        Invoke("ReturnCenter", 1.5f);
    }

    void ReturnCenter()
    {
        if (num == 1)
        {
            _anim.SetInteger("AnimState", 2);
        }
        else
        {
            _anim.SetInteger("AnimState", -2);
        }

        StartCoroutine(waitAnimation());


        Invoke("ChangePosition", 1.5f);
    }

    void Update()
    {
        if (enemy.anchoredPosition.y > 350)
        {
            enemy.anchoredPosition += new Vector2(0, -downSpeed);
        }
        if (col.enemyHealth == 0)
        {
            StopAllCoroutines();
        }
    }

    IEnumerator waitAnimation()
    {
        yield return new WaitUntil(() =>
        {
            return _anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f;
        });
        _anim.SetInteger("AnimState", 0);
        ShootPlayer();
    }


}
