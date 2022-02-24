using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
   

    private void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.collider.GetComponent<MoveEnemy>();
        if(enemy)
        {
            enemy.TakeHit(1);
        }
        Destroy(gameObject);
    }

    // Update is called once per frame

}
