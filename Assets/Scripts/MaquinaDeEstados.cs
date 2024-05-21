using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class MaquinaDeEstados : MonoBehaviour
{
    private void Start(){}
    public enum STATE
    {
        AparecerBOSS,AparecerENEMY,DeadEnemy,FinalPartida,Nada
    };
    

    public double tiempoEnemigos = 2.0;
    public double tiempoBoss = 20.0;

    public STATE state = STATE.Nada;
   
    private void Update()
    {
        tiempoEnemigos -= Time.deltaTime;
        tiempoBoss -= Time.deltaTime;
        if (tiempoEnemigos <= 0)
        {
            state = STATE.AparecerENEMY;
          
        }

        if (tiempoBoss <= 0)
        {
            state = STATE.AparecerBOSS;
            
        }
        if (tiempoBoss > 17.0 && tiempoBoss < 17.5)
        {
            transform.GetComponent<GeneradorEnemigos>().moverBoss();
        }




        switch (state)
        {
            case STATE.AparecerBOSS:
                transform.GetComponent<GeneradorEnemigos>().generarBoss();
                state = STATE.Nada;
                tiempoBoss = 20.0;


                break;
            case STATE.AparecerENEMY:
                transform.GetComponent<GeneradorEnemigos>().generarEnemy();
                state = STATE.Nada;
                tiempoEnemigos = 2.0;
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
