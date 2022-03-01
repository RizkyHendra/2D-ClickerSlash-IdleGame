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
    public float speed;
    Vector3 localScale;


    Rigidbody2D rb;

    
    void Start()
    {
        anim.SetBool("Walk", true);
        localScale = transform.localScale;

        hitPoint = maxHitPoint;
        rb = GetComponent<Rigidbody2D>();
        HealthBar.setHealth(hitPoint, maxHitPoint);
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            speed *= -1;
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
