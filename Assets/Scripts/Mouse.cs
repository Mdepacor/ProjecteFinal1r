using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    private GameObject menu;
    private GameObject[] construirTorres;
    private GameObject[] menuTorres;
    private GameObject lastClick;
    public Sprite[] dibujoTorre;
    // Start is called before the first frame update
    void Start()
    {
        construirTorres = GameObject.FindGameObjectsWithTag("construirTorres");

        menu = GameObject.FindGameObjectWithTag("Menu");
        menu.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);

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
                    // Cambio de posicion del menu 

                    if (click.collider.name.Contains("Torre"))
                    {
                        menu.transform.position = click.collider.transform.position;
                        lastClick = click.collider.gameObject;

                        esconderMostrar(true);
                    }

                    // Construccion de la torre

                    for (int j = 0; j < dibujoTorre.Length; j++)
                    {
                        if (click.collider.tag == dibujoTorre[j].name)
                        {
                            lastClick.GetComponent<SpriteRenderer>().sprite = dibujoTorre[j];
                            lastClick.GetComponent<BoxCollider2D>().size = new Vector2(3, 3);
                            lastClick.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
                            lastClick.transform.localScale = new Vector3(lastClick.transform.localScale.x / 2.5f, lastClick.transform.localScale.y / 2.5f, lastClick.transform.localScale.z);
                            lastClick.transform.GetChild(0).gameObject.GetComponent<DisparoTorre>().enabled = true;
                            lastClick.transform.GetChild(0).gameObject.GetComponent<CircleCollider2D>().enabled = true;
                            lastClick.transform.GetChild(0).gameObject.GetComponent<CircleCollider2D>().radius *= 2.5f;
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

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        //    RaycastHit2D click = Physics2D.Raycast(mousePos2D, Vector2.zero);
        //    if (click.collider != null)
        //    {
        //        // Cambio de posicion del menu 
        //        for (int i = 0; i < construirTorres.Length; i++)
        //        {
        //            if (click.collider == construirTorres[i].GetComponent<BoxCollider2D>())
        //            {
        //                lastClick = construirTorres[i];

        //                menu.transform.position = construirTorres[i].transform.position;

        //                esconderMostrar(true);
        //                break;
        //            }

        //            //if (click.collider == construirTorres[i].GetComponent<CircleCollider2D>())
        //            //{
        //            //    esconderMostrar(false);
        //            //    break;
        //            //}
        //        }

        //        // Construccion de la torre
        //        for (int i = 0; i < menuTorres.Length; i++)
        //        {
        //            if (click.collider == menuTorres[i].GetComponent<BoxCollider2D>())
        //            {
        //                for (int j = 0; j < dibujoTorre.Length; j++)
        //                {
        //                    if (menuTorres[i].tag == dibujoTorre[j].name)
        //                    {
        //                        lastClick.GetComponent<SpriteRenderer>().sprite = dibujoTorre[j];
        //                        lastClick.GetComponent<BoxCollider2D>().size = new Vector2(3, 3);
        //                        //lastClick.GetComponent<CircleCollider2D>().radius *= 2.5f;
        //                        lastClick.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
        //                        lastClick.transform.localScale = new Vector3(lastClick.transform.localScale.x / 2.5f, lastClick.transform.localScale.y / 2.5f, lastClick.transform.localScale.z);
        //                        lastClick.transform.GetChild(0).gameObject.GetComponent<DisparoTorre>().enabled = true;
        //                        lastClick.transform.GetChild(0).gameObject.GetComponent<CircleCollider2D>().radius *= 2.5f;
        //                        esconderMostrar(false);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        esconderMostrar(false);
        //    }
        //}
    }

    private void esconderMostrar(bool trueFalse)
    {
        menu.GetComponent<SpriteRenderer>().enabled = trueFalse;

        foreach (GameObject t in menuTorres)
        {
            t.GetComponent<SpriteRenderer>().enabled = trueFalse;
        }

        if (trueFalse)
        {
            menu.transform.position = new Vector3(menu.transform.position.x, menu.transform.position.y, -5);
        }
        else
        {
            menu.transform.position = new Vector3(menu.transform.position.x, menu.transform.position.y, 5);
        }
        
    }
}
