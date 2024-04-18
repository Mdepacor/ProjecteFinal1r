using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemigos : MonoBehaviour
{
    public GameObject enemy;
    public GameObject spawn;
    private List<GameObject> enemigos;
    public GameObject[] _prefabs;

    public double tiempo = 2;

    // Start is called before the first frame update
    void Start()
    {

        enemy = GameObject.FindGameObjectWithTag("Enemigos");
        spawn = GameObject.FindGameObjectWithTag("Spawn");

        for (int i = 0; i < 30; i++)
        {
            enemigos.Add(enemy);  
        }

    }

    // Update is called once per frame
    void Update()
    {

        tiempo -= Time.deltaTime;
        Debug.Log(tiempo);
        if (tiempo <= 0)
        {

            Instantiate(_prefabs[0],spawn.transform.position,spawn.transform.rotation);
            tiempo = 10.0;
        }



    }
}
