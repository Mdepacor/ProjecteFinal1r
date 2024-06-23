using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Pool : MonoBehaviour
{
    public int defeatedEnemies;
    public GameObject[] enemyPrefabs;
    public List<GameObject> enemyPool = new List<GameObject>();
    [SerializeField] private int poolSize = 20;
    private Pool instance;
    private Random rand;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }else 
        {
        Destroy(gameObject);
        }
    }

    void Start()
    {

        rand = new Random();
        addEnemysToPool(poolSize);
       
    }
    private void addEnemysToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject enemy = Instantiate(enemyPrefabs[rand.Next(0, 3)], transform);
            enemy.SetActive(false);
            enemyPool.Add(enemy);


        }
    }

    public Pool GetEnemy()
    {
        
        return instance;
        
    }
    public GameObject requestEnemy()
    {
        for (int i = 0; i < enemyPool.Count; i++)
        {
            if (!enemyPool[i].activeSelf)
            {
                enemyPool[i].SetActive(true);
                
                return enemyPool[i];
            }
        }
        addEnemysToPool(1);
        enemyPool[enemyPool.Count-1].SetActive(true);
        return enemyPool[enemyPool.Count - 1];
    }

   
}