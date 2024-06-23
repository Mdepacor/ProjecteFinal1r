using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Mouse : MonoBehaviour
{
    private GameObject menu;
    public GameObject[] construirTorres;
    private GameObject[] menuTorres;
    private GameObject lastClick;
    public Sprite[] dibujoTorre;
    private Coins monedas;
    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.FindGameObjectWithTag("Menu");
        menu.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);

        monedas = FindAnyObjectByType<Coins>();

        menuTorres = new GameObject[menu.transform.childCount];

        for (int i = 0; i < menu.transform.childCount; i++)
        {
            menuTorres[i] = menu.transform.GetChild(i).gameObject;
        }

        esconderMostrar(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                RaycastHit2D click = Physics2D.Raycast(mousePos2D, Vector2.zero);
                if (click.collider != null)
                {

                    if (click.collider.isTrigger)
                    {
                        menu.transform.position = click.collider.transform.position;
                        lastClick = click.collider.gameObject;
                        mostrarDeleteTower();
                    }

                    if (click.collider.tag == "DeleteTower")
                    {
                        Destroy(lastClick);
                        monedas.setCoins((int) lastClick.GetComponent<DisparoTorre>().coinsNecesarias / 2);
                        esconderMostrar(false);
                    }

                    // Cambio de posicion del menu 

                    if (click.collider.name.Contains("Torre"))
                    {
                        menu.transform.position = click.collider.transform.position;
                        lastClick = click.collider.gameObject;

                        if (click.collider.tag != "Torre")
                        {
                            esconderMostrar(true);
                        }
                    }

                    // Construccion de la torre

                    for (int j = 0; j < dibujoTorre.Length; j++)
                    {
                        if (click.collider.tag == dibujoTorre[j].name)
                        {
                            if (monedas.numCoins >= construirTorres[j].GetComponent<DisparoTorre>().coinsNecesarias)
                            {
                                GameObject torre = Instantiate(construirTorres[j], lastClick.transform);
                                torre.transform.position = lastClick.transform.position;
                                monedas.restarDinero((int) construirTorres[j].GetComponent<DisparoTorre>().coinsNecesarias);
                            }
                            
                            esconderMostrar(false);
                        }
                    }
                }
                else
                {
                    esconderMostrar(false);
                }
            }
        }

        //if (Time.timeScale == 1)
        //{
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        //        RaycastHit2D click = Physics2D.Raycast(mousePos2D, Vector2.zero);
        //        if (click.collider != null)
        //        {
        //            // Cambio de posicion del menu 

        //            if (click.collider.name.Contains("Torre"))
        //            {
        //                menu.transform.position = click.collider.transform.position;
        //                lastClick = click.collider.gameObject;

        //                esconderMostrar(true);
        //            }

        //            // Construccion de la torre

        //            for (int j = 0; j < dibujoTorre.Length; j++)
        //            {
        //                if (click.collider.tag == dibujoTorre[j].name)
        //                {
        //                    lastClick.GetComponent<SpriteRenderer>().sprite = dibujoTorre[j];
        //                    lastClick.GetComponent<BoxCollider2D>().size = new Vector2(3, 3);
        //                    lastClick.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
        //                    lastClick.transform.localScale = new Vector3(lastClick.transform.localScale.x / 2.5f, lastClick.transform.localScale.y / 2.5f, lastClick.transform.localScale.z);
        //                    lastClick.transform.GetChild(0).gameObject.GetComponent<DisparoTorre>().enabled = true;
        //                    lastClick.transform.GetChild(0).gameObject.GetComponent<CircleCollider2D>().enabled = true;
        //                    lastClick.transform.GetChild(0).gameObject.GetComponent<CircleCollider2D>().radius *= 2.5f;
        //                    esconderMostrar(false);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            esconderMostrar(false);
        //        }
        //    }
        //}
    }

    private void esconderMostrar(bool trueFalse)
    {
        menu.GetComponent<SpriteRenderer>().enabled = trueFalse;

        foreach (GameObject t in menuTorres)
        {
            t.GetComponent<SpriteRenderer>().enabled = trueFalse;

            try
            {
                t.GetComponentInChildren<TMP_Text>().enabled = trueFalse;
            }
            catch (Exception e)
            {
                e = new Exception();
            }
        }

        GameObject delete = GameObject.FindGameObjectWithTag("DeleteTower");
        delete.GetComponent<SpriteRenderer>().enabled = false;

        if (trueFalse)
        {
            menu.transform.position = new Vector3(menu.transform.position.x, menu.transform.position.y, -5);
        }
        else
        {
            menu.transform.position = new Vector3(menu.transform.position.x, menu.transform.position.y, 5);
        }
        
    }

    private void mostrarDeleteTower()
    {
        menu.GetComponent<SpriteRenderer>().enabled = true;
        GameObject delete = GameObject.FindGameObjectWithTag("DeleteTower");
        delete.GetComponent<SpriteRenderer>().enabled = true;
    }
}
