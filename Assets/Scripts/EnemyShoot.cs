using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject enemyBullet;
    public GameObject emisor;
    public float speed = 100;
    Animator _anim;

    void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void Shoot()
    {
        
        _anim.SetInteger("AnimState",5);
        StartCoroutine(waitAnimation());
    }

    IEnumerator waitAnimation()
    {
        yield return new WaitUntil(()=>{
            return _anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Shoot") &&
            _anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= .9f;
        });
        var newBullet = Instantiate(enemyBullet, emisor.transform.position, Quaternion.identity);

        var bulletRB = newBullet.GetComponent<Rigidbody2D>();
        bulletRB.velocity = new Vector2(0, -speed);

        Destroy(newBullet, 2.5f);
        _anim.SetInteger("AnimState",0);
    }

}
