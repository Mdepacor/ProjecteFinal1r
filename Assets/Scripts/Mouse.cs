using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.FindGameObjectWithTag("Menu");
        menu.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        menu.SetActive(false);
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
                menu.transform.position = transform.position;
                menu.SetActive(true);
            }
        }
    }
}
