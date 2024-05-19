using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castillo : MonoBehaviour
{
    public int vida;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(vida <= 0)
        {
            Debug.Log("Has perdido, se pausara el juego");
            transform.GetComponent<Castillo>().enabled = false;
            transform.GetComponent<SpriteRenderer>().enabled = false;
            Time.timeScale = 0;

        }
    }

    public void SetVida(int damage)
    {
        vida -= damage;
    }
}
