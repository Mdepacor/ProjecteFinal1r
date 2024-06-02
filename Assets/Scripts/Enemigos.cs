using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    // Start is called before the first frame update
    public event Action OnChangeHealth;

    public int vidaMax;
    public int vidaRestante;
    public int damageCastillo;
    //GameObject barra;
    void Start()
    {
        vidaRestante = vidaMax;
        //barra = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            GameObject castillo = GameObject.FindWithTag("Castillo");
            castillo.GetComponent<Castillo>().SetVida(damageCastillo);

           transform.gameObject.SetActive(false);
            transform.GetComponent<Movimiento>().contador = 0;
            vidaRestante = vidaMax;

        }
    }

    public void SetVida(int damage)
    {
        vidaRestante -= damage;

        if (vidaRestante <= 0)
        {
            transform.gameObject.SetActive(false);
            transform.GetComponent<Movimiento>().contador = 0;
            vidaRestante = vidaMax;

        }

        UpdateHealth();
    }
    public int GetVida() 
    { 
        return vidaRestante;
    }

    public void UpdateHealth()
    {
        OnChangeHealth?.Invoke();
    }
   
}
