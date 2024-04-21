using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velocidad;
    private GameObject[] checkpoint;
    private int contador;
    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
        checkpoint = GameObject.FindGameObjectsWithTag("Checkpoint");
        Array.Sort(checkpoint, (a, b) => a.name.CompareTo(b.name));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direccion = checkpoint[contador].transform.position - transform.position;

        transform.position = transform.position + (direccion.normalized * velocidad * Time.deltaTime);
        float restaX = transform.position.x - checkpoint[contador].transform.position.x;
        float restaY = transform.position.y - checkpoint[contador].transform.position.y;

        if (Mathf.Abs(restaX) <= 0.15 && Mathf.Abs(restaY) <= 0.15)
        {
            
            if (contador < checkpoint.Length - 1)
            {
                contador++;
            }
        }
    }
}
