using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public GameObject blood;

    // HitPoint
    public float hitPoint;
    public float maxHitPoint = 5;
    public EnemyHealth HealthBar;
    void Start()
    {
        hitPoint = maxHitPoint;
        HealthBar.setHealth(hitPoint, maxHitPoint);
    }

 

    public void TakeHit(float damage)
    {
        hitPoint -= damage;
        HealthBar.setHealth(hitPoint, maxHitPoint);
        if (hitPoint <= 0)
        {
            Destroy(gameObject);
            Instantiate(blood, transform.position, Quaternion.identity);
        }
    }

  
}
