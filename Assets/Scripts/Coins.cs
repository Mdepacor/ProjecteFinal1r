using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Coins : MonoBehaviour
{
    public int  numCoins;
    public GameObject coin;
 



    // Start is called before the first frame update
    void Start()
    {
        numCoins = 100; 
    }

    // Update is called once per frame
    void Update()
    {
        coin.GetComponent<TMP_Text>().text = numCoins.ToString();
    }
    public int  getCoins()
    {
        return numCoins;
    }
    public void more()
    {
        numCoins++;
    }

    public void setCoins(int numC)
    {
        numCoins += numC;
    }
    public void restarDinero()
    {

    }
}
