using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pausemenu : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject optionPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void mostrarPausePanel()
    {
        pausePanel.SetActive(true);
        pausePanel.transform.SetAsLastSibling();
        Pause();
    }

    public void esconderPausePanel()
    {
        pausePanel.SetActive(false);
        Resume();
    }

    public void mostrarMenuOpciones()
    {
        pausePanel.SetActive(false);
        optionPanel.SetActive(true);
    }

    public void volverPausePanel()
    {
        pausePanel.SetActive(true);
        optionPanel.SetActive(false);
    }

    public void volverMenuInicio()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
