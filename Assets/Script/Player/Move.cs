using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    float dirX, moveSpeed = 5f;
    bool facingRight = true;
    bool Hurt, die;
    Vector3 localScale;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && !die && rb.velocity.y == 0)
        {
            rb.AddForce(Vector2.up * 600f);
        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 10f;
        }
        else
        {
            moveSpeed = 5;
        }
        setAnimationState();
        if(!die)
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        
    }
     void FixedUpdate()
    {
        if(!Hurt)
     
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

     void LateUpdate()
    {
        checkWhereToFace();
    }

    void setAnimationState()
    {
        if (dirX == 0)
        {
            anim.SetBool("Run", false);
        }
        if (rb.velocity.y == 0)
        {
            anim.SetBool("Jump", false);
            anim.SetBool("Fall", false);
        }
        if (Mathf.Abs(dirX) == 5 && rb.velocity.y == 0)
        {
            anim.SetBool("Run", true);
        }

        if (Input.GetKey(KeyCode.DownArrow) && Mathf.Abs(dirX) == 5)
        {
            anim.SetBool("Dash", true);
        }
        else
        {
            anim.SetBool("Dash", false);
        }

        if(rb.velocity.y > 0)
        {
            anim.SetBool("Jump", true);
        }
        if(rb.velocity.y < 0)
        {
            anim.SetBool("Jump", false);
            anim.SetBool("Fall", true);
        }
    }
    void checkWhereToFace()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;
        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;
        transform.localScale = localScale;
    }
}
