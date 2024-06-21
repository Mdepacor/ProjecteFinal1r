using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TMPro;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class MaquinaDeEstados : MonoBehaviour
{

    public int waveCount;
    public int wave;
    public int CantidadBoss ;
    private int dificultad;
    private int count;
    public bool spawning;
    private int enemiesSpawned;
    public int enemiesDefeated;
    public GameObject waves;
    
    
    // Start is called before the first frame update
    void Start()
    {
        CantidadBoss = 0;
        waveCount = 2;
        wave = 1;
        spawning = false;
        enemiesSpawned = 0;
        enemiesDefeated = 0;
        dificultad = 1;
        waves.GetComponent<TMP_Text>().text = wave.ToString();

    }

    // Update is called once per frame
   
    IEnumerator SpawnWave(int waveC)
    {

        spawning = true;
        yield return new WaitForSeconds(4);
        for (int i = 0; i < waveC; i++)
        {
            spawnEnemies(wave);
            yield return new WaitForSeconds(1);
        }
        wave += 1;
        waves.GetComponent<TMP_Text>().text = wave.ToString();

        if (wave %5== 0)
        {
            CantidadBoss = 1;
        }
        if (count==9)
        {
            count = 0;
            dificultad++;
        }
        else
        {
            count++;
        }
        waveCount += 2*dificultad;
        spawning = false;
        yield break;
    }
    private void spawnEnemies(int wave)
    {
       
        
        state = STATE.AparecerENEMY;
        
        if(CantidadBoss >=1)
        {
            new WaitForSeconds(4);
            state = STATE.AparecerBOSS;
            tiempoBoss = 20.0;
            CantidadBoss--; ;
        }
    }
    public enum STATE
    {
        AparecerBOSS,AparecerENEMY,DeadEnemy,FinalPartida,Nada
    };
    

    //public double tiempoEnemigos = 2.0;
    public double tiempoBoss = 0;

    public STATE state = STATE.Nada;
   
    private void Update()
    {

        
        //int def = transform.GetComponent<Enemigos>().ReturnDefeatedEnemies();
        if (spawning == false && enemiesSpawned == enemiesDefeated)
        {
            StartCoroutine(SpawnWave(waveCount));
        }
        //tiempoEnemigos -= Time.deltaTime;
        tiempoBoss -= Time.deltaTime;
        //if (tiempoEnemigos <= 0)
        //{
        //    state = STATE.AparecerENEMY;
        //  
        //}
        //
        //if (tiempoBoss <= 0)
        //{
        //    state = STATE.AparecerBOSS;
        //    
        //}
        if (tiempoBoss > 17.0 && tiempoBoss < 17.5 )
        {
            transform.GetComponent<GeneradorEnemigos>().moverBoss();
        }




        switch (state)
        {
            case STATE.AparecerBOSS:
                transform.GetComponent<GeneradorEnemigos>().generarBoss(dificultad);
                enemiesSpawned++;
                state = STATE.Nada;
                tiempoBoss = 20.0;



                break;
            case STATE.AparecerENEMY:
                transform.GetComponent<GeneradorEnemigos>().generarEnemy();
                enemiesSpawned++;
                state = STATE.Nada;
                //tiempoEnemigos = 2.0;
                break;
            case STATE.DeadEnemy:
                break;
            case STATE.FinalPartida:
                break;
            case STATE.Nada:
                break;
            default:
                break;
        }
    }
}
