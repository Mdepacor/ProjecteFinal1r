using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoBala : MonoBehaviour
{
    public int damage;
    public GameObject enemy;
    public float velocidad;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        transform.position += new Vector3(0, 0, -5);
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direccion = enemy.transform.position - transform.position;

        transform.position = transform.position + (direccion.normalized * velocidad * Time.deltaTime);

        time += Time.deltaTime;

        if (time >= 2)
        {
            BalaPerdida();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemigos" || collision.gameObject.tag == "Boss")
        {
            enemy.GetComponent<Enemigos>().SetVida(damage);
            Destroy(gameObject);
        }
    }

    private void BalaPerdida()
    {
        Destroy(gameObject);
    }
}
