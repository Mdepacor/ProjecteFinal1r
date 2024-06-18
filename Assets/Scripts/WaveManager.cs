using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject[] enemies;
    public int waveCount;
    public int wave;
    public int enemyType;
    public bool spawning;
    private int enemiesSpawned;
    private Pool enemigos;
    // Start is called before the first frame update
    void Start()
    {
        waveCount = 2;
        wave = 1;
        spawning = false;
        enemiesSpawned = 0;

    }

    // Update is called once per frame
    void Update()
    {
 
        if (spawning==false )
        {
            StartCoroutine(SpawnWave(waveCount)); 
        }
    }
    IEnumerator SpawnWave(int waveC)
    {

        spawning = true;
        yield return new WaitForSeconds(4);
        for (int i = 0; i < waveC; i++)
        {
            spawnEnemies(wave); 
            yield return new WaitForSeconds(2);
        }
        wave += 1;
        waveCount += 2;
        spawning=false;
        yield break;
    }
    private void spawnEnemies(int wave)
    {
        if (wave < 5)
        {
            
        }
    }
}
