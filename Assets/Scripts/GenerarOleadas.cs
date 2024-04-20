using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemigos : MonoBehaviour
{
    private GameObject spawn;
    public GameObject[] _prefabs;


    private double tiempoEnemigos;
    private double tiempoBoss;
    private Cam cam;
    private Movimiento velocidad;
    private GameObject[] boss;
   




    // Start is called before the first frame update
    void Start()
    {
        spawn = GameObject.FindGameObjectWithTag("Spawn");
        cam= FindAnyObjectByType<Cam>(); 
        velocidad= FindAnyObjectByType<Movimiento>();    


        tiempoEnemigos = 2.0;
        tiempoBoss = 10.0;
        

       
    }

    // Update is called once per frame
    void Update()
    {

        tiempoEnemigos -= Time.deltaTime;
        tiempoBoss -= Time.deltaTime;

        if (tiempoEnemigos <= 0)
        {
            Instantiate(_prefabs[0],spawn.transform.position,spawn.transform.rotation);
            tiempoEnemigos = 2.0;
            
        }

        if (tiempoBoss <= 0)
        {
            Instantiate(_prefabs[1], spawn.transform.position, spawn.transform.rotation);
            boss = GameObject.FindGameObjectsWithTag("Boss");
            int posicion = boss.Length;
             boss[posicion-1].GetComponent<Movimiento>().velocidad = 0;
            cam.zoomInZoomOut(boss[posicion-1].transform.position,7f);
            tiempoBoss = 10.0;
            


        }
        
        if (tiempoBoss > 7.0 && tiempoBoss < 7.5) 
        {
            try
            {
                int posicion = boss.Length;
                boss[posicion-1].GetComponent<Movimiento>().velocidad = 5;
                
                cam.zoomInZoomOut(new Vector3(0,0,-10),14);
            }
            catch (Exception e)
            {
                Exception a = e;
            }
        }

    }
}
