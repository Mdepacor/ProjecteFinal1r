using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemigos : MonoBehaviour
{
    public GameObject enemy;
    public GameObject spawn;
    public GameObject[] _prefabs;

    public double tiempo;

    // Start is called before the first frame update
    void Start()
    {
        spawn = GameObject.FindGameObjectWithTag("Spawn");

        tiempo = 2.0;

    }

    // Update is called once per frame
    void Update()
    {

        tiempo -= Time.deltaTime;
        if (tiempo <= 0)
        {
            Instantiate(_prefabs[0],spawn.transform.position,spawn.transform.rotation);
            tiempo = 2.0;
        }



    }
}
