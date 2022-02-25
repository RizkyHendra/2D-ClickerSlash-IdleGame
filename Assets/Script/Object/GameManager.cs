using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    private static GameManager _instace = null;
    public static GameManager Instance
    {
        get
        {
            if(_instace == null)
            {
                _instace = FindObjectOfType<GameManager>();
            }
            return _instace;
        }
    }

    [Range(0f, 01f)]
    public float AutoCollectPercentage = 0.1f;
    

    public Text goldInfo;
    public Text AutoCollectInfo;
    private float _collectSecond;
    private double _totalGold;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _collectSecond += Time.unscaledDeltaTime;
        if(_collectSecond >= 1f)
        {
            CollectPerSecond();
            _collectSecond = 0f;
            
        }
    }

    void CollectPerSecond()
    {
        double output = 0;
        AutoCollectInfo.text = $"Auto Collect: { output.ToString("F1") } / second";


        output *= AutoCollectPercentage;
        AddGold(output);
    }

    public void AddGold(double value)
    {
        _totalGold += value;
        goldInfo.text = $"Gold: { _totalGold.ToString("0") }";
    }

}
