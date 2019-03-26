using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    GameObject canvas;
    public float minSpawnTime = 40, maxSpawnTime = 70;

    void Awake()
    {
        canvas = GameObject.Find("Canvas");
    }

    void Start()
    {
        Invoke("Spawn", Random.Range(minSpawnTime, maxSpawnTime));
    }

   void Spawn()
    {
        var newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
        newEnemy.transform.SetParent(canvas.transform, false);
        newEnemy.transform.position = transform.position;
        Invoke("Spawn", Random.Range(minSpawnTime, maxSpawnTime));
    }
}
