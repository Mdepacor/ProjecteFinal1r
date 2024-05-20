using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoTorre : MonoBehaviour
{

    public GameObject[] _prefabs;
    //private Sprite asprite;
    private float time;
    public float recargarDisparo;
   
    private GameObject bala;


    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

    }


    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Enemigos" || collision.gameObject.tag == "Boss")
    //    {
    //        if (transform.GetComponent<SpriteRenderer>().sprite != asprite)
    //        {
    //            Instantiate(_prefabs[0], transform.position, transform.rotation);

    //            DañoBala bala = FindAnyObjectByType<DañoBala>();
    //            bala.enemy = collision.gameObject;
    //        }
    //    }
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (time >= recargarDisparo)
        {
            if (collision.gameObject.tag == "Enemigos" || collision.gameObject.tag == "Boss")
            {
                
                 bala = Instantiate(_prefabs[0], transform.position, transform.rotation);

                bala.GetComponent<DañoBala>().SetEnemigo(collision.gameObject);
            }
            

            time = 0;
        }
    }
  
}
