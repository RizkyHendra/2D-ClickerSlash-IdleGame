using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScirp : MonoBehaviour
{
    private static ScoreScirp _instance = null;

    public static ScoreScirp Instance

    {

        get

        {

            if (_instance == null)

            {

                _instance = FindObjectOfType<ScoreScirp>();

            }



            return _instance;

        }

    }
    [Range(0f, 1f)]
   

    public float AutoCollectPercentage = 0.1f;
    public static float scoreValue = 0.1f;
    Text score;
    private double _totalGold;
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreValue += Time.unscaledDeltaTime;

        score.text = $"Auto Collect: { scoreValue.ToString("F1") } / second" ;
       
        
    }
    private void AddGold(double value)

    {

        _totalGold += value;

        score.text = $"Gold: { _totalGold.ToString("0") }";

    }
}
