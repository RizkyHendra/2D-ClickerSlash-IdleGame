using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    // Store Panel Object
    public Button RedTREX, BlueTREX, GreenTREX;
    public GameObject RedTREXSold, BlueTREXSold, GreenTREXSold;
    public Text RedTREXTextprice, BlueTREXTextprice, GreenTREXTextprice;

    // Game Panel Object
    public GameObject TREXRED, TREXBLUE, TREXGREEN;
    public Text GoldText;
    public static  int GoldAmount;

    // Common Variable
    private bool isTREXREDSold, isTREXBLUESold, isTREXGREENSold;
    public int TREXREDPRICE = 10, TREXBLUEPRICE = 20, TREXGREENPRICE = 30;
    void Start()
    {
        TREXRED.gameObject.SetActive(false);
        TREXBLUE.gameObject.SetActive(false);
        TREXGREEN.gameObject.SetActive(false);

        //disable button in the store;
        RedTREX.interactable = false;
        BlueTREX.interactable = false;
        GreenTREX.interactable = false;

        // set prices for goods
        RedTREXTextprice.text = TREXREDPRICE.ToString() + " GOLD ";
        BlueTREXTextprice.text = TREXBLUEPRICE.ToString() + " GOLD ";
        GreenTREXTextprice.text = TREXGREENPRICE.ToString() + " GOLD ";
    }
    void Update()
    {
        GoldText.text = GoldAmount + " GOLD ";
        DoyouEnoguGold();
    }

    public   void IncreseGoldAmount()
    {
        GoldAmount += 1;
    }
    public void SellTREXRED()
    {
        TREXRED.gameObject.SetActive(true);
        GoldAmount -= TREXREDPRICE;
        isTREXREDSold = true;
        RedTREXSold.gameObject.SetActive(true);
        RedTREXTextprice.gameObject.SetActive(false);


    }
    public void SellTREXBLUE ()
    {
        TREXBLUE.gameObject.SetActive(true);
        GoldAmount -= TREXBLUEPRICE;
        isTREXBLUESold = true;
        BlueTREXSold.gameObject.SetActive(true);
        BlueTREXTextprice.gameObject.SetActive(false);


    }

    public void SellTREXGREEN()
    {
        TREXGREEN.gameObject.SetActive(true);
        GoldAmount -= TREXGREENPRICE;
        isTREXGREENSold = true;
        GreenTREXSold.gameObject.SetActive(true);
        GreenTREXTextprice.gameObject.SetActive(false);


    }

    void DoyouEnoguGold()
    {
        if(GoldAmount < TREXREDPRICE)
        {
            RedTREX.interactable = false;
        }
        if (GoldAmount < TREXBLUEPRICE)
        {
            BlueTREX.interactable = false;
        }
        if (GoldAmount < TREXGREENPRICE)
        {
            GreenTREX.interactable = false;
        }

        if(!isTREXREDSold && GoldAmount >= TREXREDPRICE)
        {
            RedTREX.interactable = true;
        }
        if (!isTREXBLUESold && GoldAmount >= TREXBLUEPRICE)
        {
            BlueTREX.interactable = true;
        }
        if (!isTREXGREENSold && GoldAmount >= TREXGREENPRICE)
        {
            GreenTREX.interactable = true;
        }
    }
    // Update is called once per frame
   
}
