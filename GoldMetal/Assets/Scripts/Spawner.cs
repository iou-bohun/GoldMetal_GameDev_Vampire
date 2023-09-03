using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Accessibility;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public float spawnCoolTime;
    float timer;

    private void Awake()
    {
        spawnPoints = GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnCoolTime) {
            Spawn();
            timer = 0;
        }
    }

    void Spawn()
    {
        /*GameObject enemy = GameManager.Instance.pool.Get(Random.RandomRange(0,2));
        enemy.transform.position = spawnPoints[Random.Range(1,spawnPoints.Length)].position;*/
        GameManager.Instance.pool.Get(1);
    }
}
