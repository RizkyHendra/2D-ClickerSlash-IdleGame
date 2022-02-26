using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameControl Amount;

    private void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.collider.GetComponent<MoveEnemy>();
        if(enemy)
        {
            Amount.IncreseGoldAmount();
            enemy.TakeHit(1);
        }
        Destroy(gameObject);
    }

    // Update is called once per frame

}
