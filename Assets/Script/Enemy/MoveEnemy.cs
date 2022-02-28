using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    //public GameObject blood;

    // HitPoint
    public GameObject blood;
    public Animator anim;
    public float hitPoint;
    public float maxHitPoint = 5;
    public EnemyHealth HealthBar;
    public GameObject Demon, DemonPurple;


    Rigidbody2D rb;

      LayerMask playerLayer, enemyLayer;
    void Start()
    {
       
        
       
        hitPoint = maxHitPoint;
        HealthBar.setHealth(hitPoint, maxHitPoint);
    }

    private void Update()
    {
        if (Demon == false)
        {
            DemonPurple.SetActive(true);
        }


        if (DemonPurple == false)
        {
            Demon.SetActive(true);
        }
    }



    public void TakeHit(float damage)
    {
        anim.SetTrigger("Hurt");
        hitPoint -= damage;
        HealthBar.setHealth(hitPoint, maxHitPoint);
        if (hitPoint <= 0)
        {
            Die1();
            



        }
    }

    public void Die1()
    {
        ScoreScirp.scoreValue += 10;
        StartCoroutine("Die");

        gameObject.layer = 9;

    }

 

    IEnumerator Die()
    {
        anim.SetTrigger("Die");
       
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
        Instantiate(blood, transform.position, Quaternion.identity);



    }




}
