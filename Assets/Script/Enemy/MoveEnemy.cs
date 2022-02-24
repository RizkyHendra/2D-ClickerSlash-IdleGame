using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public GameObject blood;

    // HitPoint
    public Animator anim;
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
        anim.SetTrigger("Hurt");
        hitPoint -= damage;
        HealthBar.setHealth(hitPoint, maxHitPoint);
        if (hitPoint <= 0)
        {
            StartCoroutine("Die");

        }
    }

    IEnumerator Die()
    {
        anim.SetTrigger("Die");
       
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
        Instantiate(blood, transform.position, Quaternion.identity);



    }




}
