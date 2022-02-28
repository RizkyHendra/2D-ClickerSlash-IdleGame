using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnControl : MonoBehaviour
{
    public GameObject Demon, DemonPurple;
    

    public void Start()
    {
        
    }

    public void Update()
    {
        if(Demon == false)
        {
            DemonPurple.SetActive(true);
        }


        if(DemonPurple == false)
        {
            Demon.SetActive(true);
        }
       
    }
}
