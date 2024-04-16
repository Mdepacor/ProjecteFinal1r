using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    GameObject menu;
    GameObject[] construirTorres;
    // Start is called before the first frame update
    void Start()
    {
        construirTorres = GameObject.FindGameObjectsWithTag("construirTorres");
        menu = GameObject.FindGameObjectWithTag("Menu");
        menu.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        menu.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D click = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (click.collider != null)
            {
                for (int i = 0; i < construirTorres.Length; i++)
                {
                    if (click.collider == construirTorres[i].GetComponent<CircleCollider2D>())
                    {
                        menu.transform.position = construirTorres[i].transform.position;
                        menu.GetComponent<SpriteRenderer>().enabled = true;
                        break;
                    }
                }
            }
            else
            {
                menu.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}
