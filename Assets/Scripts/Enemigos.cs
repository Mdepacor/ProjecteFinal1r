using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    // Start is called before the first frame update

    int vida;
    //GameObject barra;
    void Start()
    {
        vida = 1;
        //barra = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (vida < 1) 
        { 
            Destroy(gameObject);
        
        
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            Destroy(gameObject);
         
            

        }
    }
}
