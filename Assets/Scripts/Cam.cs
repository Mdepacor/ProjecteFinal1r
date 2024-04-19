using System.Collections;
using System.Collections.Generic;
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
    public void zoomInZoomOut(Vector3 boss)
    {

        gameObject.transform.position = new Vector3(boss.x,boss.y,-10 );
        gameObject.GetComponent<Camera>().orthographicSize = 7;
        //Debug.Log(boss);
        //Debug.Log(gameObject);

    }
}
