using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class GeneradorEnemigos : MonoBehaviour
{
    private GameObject spawn;
    public GameObject[] _prefabs;

    //private double tiempoEnemigos;
    private double tiempoBoss;
    private Cam cam;
    private Movimiento velocidad;
    private GameObject[] boss;
    public int enemiesDefeated;
   




    // Start is called before the first frame update
    void Start()
    {
        spawn = GameObject.FindGameObjectWithTag("Spawn");
        cam= FindAnyObjectByType<Cam>(); 
        velocidad= FindAnyObjectByType<Movimiento>();
        enemiesDefeated = 0;

        //tiempoEnemigos = 2.0;
        tiempoBoss = 20.0;
        

       
    }

    // Update is called once per frame
    void Update()
    {

        //tiempoEnemigos -= Time.deltaTime;
        //tiempoBoss -= Time.deltaTime;
        //
        //if (tiempoEnemigos <= 0)
        //{
        //    Instantiate(_prefabs[0],spawn.transform.position,spawn.transform.rotation);
        //    tiempoEnemigos = 2.0;
        //    
        //}

        if (tiempoBoss <= 0)
        {
            //Instantiate(_prefabs[1], spawn.transform.position, spawn.transform.rotation);
            //boss = GameObject.FindGameObjectsWithTag("Boss");
            //int posicion = boss.Length;
            // boss[posicion-1].GetComponent<Movimiento>().velocidad = 0;
            //cam.zoomInZoomOut(boss[posicion-1].transform.position,7f);
            tiempoBoss = 20.0;
           

          }
        
        if (tiempoBoss > 17.0 && tiempoBoss < 17.5) 
        {
            try
            {
                int posicion = boss.Length;
                boss[posicion-1].GetComponent<Movimiento>().velocidad = 5;
                
                cam.zoomInZoomOut(new Vector3(0,0,-10),13f);
            }
            catch (Exception e)
            {
                e = new Exception();
            }
        }

    }



    public void generarBoss()
    {
        Instantiate(_prefabs[1], spawn.transform.position, spawn.transform.rotation);
        enemiesDefeated++;
        boss = GameObject.FindGameObjectsWithTag("Boss");
        int posicion = boss.Length;
        boss[posicion - 1].GetComponent<Movimiento>().velocidad = 0;
        cam.zoomInZoomOut(boss[posicion - 1].transform.position, 7f);

    }
    public void generarEnemy()
    {
        //Instantiate(_prefabs[0],spawn.transform.position,spawn.transform.rotation);
        GameObject enemy= transform.GetComponent<Pool>().requestEnemy();
        enemiesDefeated++;
        enemy.transform.position = spawn.transform.position;
       
    }
    public void moverBoss() 
    {
       
            try
            {
                int posicion = boss.Length;
                boss[posicion - 1].GetComponent<Movimiento>().velocidad = 5;

                cam.zoomInZoomOut(new Vector3(0, 0, -10), 14.5f);
            }
            catch (Exception e)
            {
                e = new Exception();
            }
       
    }
    

}
