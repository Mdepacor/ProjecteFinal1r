using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoTorre : MonoBehaviour
{

    public GameObject[] _prefabs;
    private Sprite asprite;

    

    // Start is called before the first frame update
    void Start()

    {
        asprite = transform.GetComponent<SpriteRenderer>().sprite;

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        
        if (collision.gameObject.tag == "Enemigos") 
        {

            if (transform.GetComponent<SpriteRenderer>().sprite != asprite)
            {
                Instantiate(_prefabs[0], transform.position, transform.rotation);
            }


        }
    }
}
