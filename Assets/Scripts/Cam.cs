using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    private float restaX;
    private float restaY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
            
    }
    public void zoomInZoomOut(Vector3 posicion,float zoom)
    {

        //gameObject.transform.position = new Vector3(posicion.x, posicion.y,-10 );
        //gameObject.GetComponent<Camera>().orthographicSize = zoom;
        while (Mathf.Abs(restaX) <= 0.1 && Mathf.Abs(restaY) <= 0.1)
        {
            
            Vector3 direccion = posicion - gameObject.transform.position;
            gameObject.transform.position = gameObject.transform.position + (direccion.normalized * 1 * Time.deltaTime);
            restaX = gameObject.transform.position.x - posicion.x;
            restaY = gameObject.transform.position.y - posicion.y;
            Debug.Log("x"+ restaX);
            Debug.Log("y" + restaY);

        }





        //Debug.Log(boss);
        //Debug.Log(gameObject);

    }
}
