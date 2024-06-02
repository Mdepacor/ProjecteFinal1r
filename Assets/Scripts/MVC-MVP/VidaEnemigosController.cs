using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaEnemigos : MonoBehaviour
{
    Enemigos enemigos;

    RectTransform healthUI;
    RectTransform healthBar;
    RectTransform healthValue;
    public RectTransform[] healthPrefabs;

    private void Awake()
    {
        enemigos = transform.GetComponent<Enemigos>();

        healthUI = Instantiate(healthPrefabs[0], GameObject.FindGameObjectWithTag("Canvas").transform);

        healthBar = healthUI.transform.GetChild(0).GetComponent<RectTransform>();
        healthValue = healthBar.transform.GetChild(0).GetComponent<RectTransform>();
    }

    void Start()
    {
        if (enemigos != null)
        {
            enemigos.OnChangeHealth += OnHealthChanged;
            
        }
    }

    private void OnDestroy()
    {
        if (enemigos != null)
        {
            DisableImage();
            Destroy(healthUI.gameObject);
            enemigos.OnChangeHealth -= OnHealthChanged;
        }
    }

    public void RecibirDamage(int damage)
    {
        enemigos?.SetVida(damage);
    }

    // Update is called once per frame
    void Update()
    {
        healthUI.position = transform.position;
    }

    public void UpdateView()
    {
        if (enemigos == null)
            return;

        // format the data for view
        if (healthBar != null && healthValue != null && enemigos.vidaMax != 0)
        {
            float newWidht = healthBar.rect.width * (enemigos.vidaRestante / (float)enemigos.vidaMax);
            healthValue.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newWidht);
        }
    }

    // listen for model changes and update the view
    public void OnHealthChanged()
    {
        UpdateView();
    }

    private void DisableImage()
    {
        healthValue.GetComponent<Image>().enabled = false;
        healthBar.GetComponent<Image>().enabled = false;
        healthUI.GetComponent<Image>().enabled = false;
    }
}
