using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pausemenu : MonoBehaviour
{
    //GraphicRaycaster m_Raycaster;
    //PointerEventData m_PointerEventData;
    //EventSystem m_EventSystem;

    public GameObject pausePanel;
    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Raycaster from the GameObject (the Canvas)
        //m_Raycaster = GetComponent<GraphicRaycaster>();
        ////Fetch the Event System from the Scene
        //m_EventSystem = GetComponent<EventSystem>();
    }

    private void Update()
    {
        //Check if the left Mouse button is clicked
        //if (Input.GetKey(KeyCode.Mouse0))
        //{
        //    Set up the new Pointer Event
        //    m_PointerEventData = new PointerEventData(m_EventSystem);
        //    Set the Pointer Event Position to that of the mouse position
        //    m_PointerEventData.position = Input.mousePosition;

        //    Create a list of Raycast Results
        //    List<RaycastResult> results = new List<RaycastResult>();

        //    Raycast using the Graphics Raycaster and mouse click position
        //    m_Raycaster.Raycast(m_PointerEventData, results);

        //    For every result returned, output the name of the GameObject on the Canvas hit by the Ray
        //    foreach (RaycastResult result in results)
        //    {
        //        if (result.gameObject.tag == "PausePanel")
        //        {
        //            esconderPausePanel();
        //        }
        //    }
        //}
    }

    public void mostrarPausePanel()
    {
        pausePanel.SetActive(true);
        pausePanel.transform.SetAsLastSibling();
        Time.timeScale = 0;
    }

    public void esconderPausePanel()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void volverMenuInicio()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
