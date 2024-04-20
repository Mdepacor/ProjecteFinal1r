using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Cam : MonoBehaviour
{
   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   void Update()
    {
        
        
    }
    public void zoomInZoomOut(Vector3 posicion ,float zoom)
    {

        gameObject.transform.position = new Vector3(posicion.x, posicion.y,-10 );
        gameObject.GetComponent<Camera>().orthographicSize = zoom;
        

    }
}
