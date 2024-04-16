using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    float velocidad;
    GameObject[] target;
    int contador;
    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
        velocidad = 2;
        target = GameObject.FindGameObjectsWithTag("Target");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direccion = target[contador].transform.position - transform.position;

        transform.position = transform.position + (direccion.normalized * velocidad * Time.deltaTime);

        if (transform.position == target[contador].transform.position)
        {
            if (contador < target.Length - 1)
            {
                contador++;
            }
        }
    }
}
