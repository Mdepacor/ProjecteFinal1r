using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
    public GameObject menuInicio;
    public GameObject menuOpciones;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MostrarOpciones()
    {
        menuInicio.SetActive(false);
        menuOpciones.SetActive(true);
    }

    public void VolverAlMenu()
    {
        menuInicio.SetActive(true);
        menuOpciones.SetActive(false);
    }
}
