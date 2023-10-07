using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [Header("# Game Control")]
    public float gameTime;
    public float maxGameTime = 2 * 10f;
    [Header("#  Player Info")]
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = { 3,5,10, 30, 60, 150, 280, 350, 450, 600 };
    [Header("# Player Object")]
    public PoolManager pool;
    public Player player;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        gameTime += Time.deltaTime;
        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }
    }

    public void GetExp()
    {
        exp++;
        if(exp == nextExp[level])
        {
            level++;
            exp = 0;

        }
    }
}
