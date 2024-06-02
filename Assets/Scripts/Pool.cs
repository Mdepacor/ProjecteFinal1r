using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Pool : MonoBehaviour
{

    [SerializeField] private GameObject enemyPrefabs;
    public List<GameObject> enemyPool = new List<GameObject>();
    [SerializeField] private int poolSize = 20;
    private Pool instance;
    
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

        addEnemysToPool(poolSize);
       
    }
    private void addEnemysToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject enemy = Instantiate(enemyPrefabs, transform);
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
        return null;
    }

   
}