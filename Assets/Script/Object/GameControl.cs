using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    private static GameControl _instance = null;

    public static GameControl Instance

    {

        get

        {

            if (_instance == null)

            {

                _instance = FindObjectOfType<GameControl>();

            }



            return _instance;

        }

    }

    // SCORE AUTOMATIC
    public Text scoreText;
    public float scoreAmount;
    public float pointIncresePersecond;

    // Store Panel Object
    public Button RedTREX, BlueTREX, GreenTREX;
    public GameObject RedTREXSold, BlueTREXSold, GreenTREXSold;
    public Text RedTREXTextprice, BlueTREXTextprice, GreenTREXTextprice;

    // Game Panel Object
    public GameObject TREXRED, TREXBLUE, TREXGREEN;
    public Text GoldText, goldpersecondText;
    public  float GoldAmount;
    public float GoldSecond;

    // Game Loop Idle
    public GameObject Demon, DemonPurple;
    

    // Common Variable
    private bool isTREXREDSold, isTREXBLUESold, isTREXGREENSold;
    public int TREXREDPRICE = 10, TREXBLUEPRICE = 20, TREXGREENPRICE = 30;
    void Start()
    {

        // Waktu PerSecond
        scoreAmount = 0f;

        Demon.gameObject.SetActive(true);
        DemonPurple.gameObject.SetActive(false);




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

        if(Demon == false)
        {
            DemonPurple.gameObject.SetActive(true);
        }
        if (DemonPurple == false)
        {
            DemonPurple.gameObject.SetActive(true);
        }
        // Time Persecond
        GoldText.text = (int)GoldAmount + " GOLD  ";
        GoldAmount += pointIncresePersecond * Time.unscaledDeltaTime;
        goldpersecondText.text =  $" PER SECOND { GoldAmount.ToString("F1")} ";
     



        GoldText.text = (int)GoldAmount + " GOLD ";
        DoyouEnoguGold();
    }

    public   void IncreseGoldAmount()
    {
        GoldAmount += 3;
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
