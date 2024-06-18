using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class MaquinaDeEstados : MonoBehaviour
{

    public int waveCount;
    public int wave;
    public int CantidadBoss ;

    public bool spawning;
    private int enemiesSpawned;
    public int enemiesDefeated;
    private int typeE;
    // Start is called before the first frame update
    void Start()
    {
        CantidadBoss = 0;
        waveCount = 2;
        wave = 1;
        spawning = false;
        enemiesSpawned = 0;
        enemiesDefeated = 0;

    }

    // Update is called once per frame
   
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
        if (wave ==5)
        {
            CantidadBoss = 1;
        }
        waveCount += 2;
        spawning = false;
        yield break;
    }
    private void spawnEnemies(int wave)
    {
       
        
        state = STATE.AparecerENEMY;
        
        if(CantidadBoss ==1)
        {
            state = STATE.AparecerBOSS;
            tiempoBoss = 20.0;
            CantidadBoss = 0;
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

        enemiesDefeated = transform.GetComponent<GeneradorEnemigos>().enemiesDefeated;
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
                transform.GetComponent<GeneradorEnemigos>().generarBoss();
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
