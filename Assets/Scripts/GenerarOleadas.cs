using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemigos : MonoBehaviour
{
    private GameObject spawn;
    public GameObject[] _prefabs;

    public double tiempoEnemigos;
    public double tiempoBoss;

    // Start is called before the first frame update
    void Start()
    {
        spawn = GameObject.FindGameObjectWithTag("Spawn");

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
            tiempoBoss = 10.0;
        }

    }
}
