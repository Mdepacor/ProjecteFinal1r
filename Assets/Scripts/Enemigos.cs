using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    // Start is called before the first frame update
    public event Action OnChangeHealth;

   public int defeated;
    public int vidaMax;
    public int vidaRestante;
    public int damageCastillo;
    public MaquinaDeEstados maquinaDeEstados;
    public Coins coins;
    public int monedasConseguidas;

    //GameObject barra;
    void Start()
    {
        vidaRestante = vidaMax;
        defeated = 0;
        maquinaDeEstados= FindAnyObjectByType<MaquinaDeEstados>();
        coins = FindAnyObjectByType<Coins>();


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

            vidaRestante = vidaMax;
           transform.gameObject.SetActive(false);
            transform.GetComponent<Movimiento>().contador = 0;
            maquinaDeEstados.enemiesDefeated++;


        }
    }

    public void SetVida(int damage)
    {
        vidaRestante -= damage;

        if (vidaRestante <= 0)
        {
            vidaRestante = vidaMax;
            transform.gameObject.SetActive(false);
            transform.GetComponent<Movimiento>().contador = 0;
            maquinaDeEstados.enemiesDefeated++;
            coins.setCoins(monedasConseguidas);




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
