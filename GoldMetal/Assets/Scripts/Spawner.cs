using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Accessibility;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public SpawnData[] spawnData;
    public float spawnCoolTime;
    float timer;

    public int level;

    private void Awake()
    {
        spawnPoints = GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        level = Mathf.Min(Mathf.FloorToInt(GameManager.Instance.gameTime / 10f),spawnData.Length-1) ;

        if (timer > (spawnData[level].spawnTime)){
            Spawn();
            timer = 0; 
        }
    }

    void Spawn()
    {
        GameObject enemy = GameManager.Instance.pool.Get(0);
        enemy.transform.position = spawnPoints[Random.Range(1,spawnPoints.Length)].position;
        enemy.GetComponent<Enemy>().Init(spawnData[level]);
    }
}

[System.Serializable]
public class SpawnData
{
    public int spriteType;
    public float spawnTime;
    public int health;
    public int speed;
}
