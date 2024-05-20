using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    // Start is called before the first frame update

    public int vida;
    public int damageCastillo;
    //GameObject barra;
    void Start()
    {
        //barra = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0) 
        { 
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            GameObject castillo = GameObject.FindWithTag("Castillo");
            castillo.GetComponent<Castillo>().SetVida(damageCastillo);

            Destroy(gameObject);
        }
    }

    public void SetVida(int damage)
    {
        vida -= damage;
    }
    public int GetVida() 
    { 
        return vida;
    }
}
