using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    float dirX, moveSpeed = 5f;
    public bool facingRight ;
    bool Hurt, die;
    Vector3 localScale;

    // Shoot
    [SerializeField]
    private Transform barrel, BARREl;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject[] ammo;

    private int ammoAmount;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;

        // FIRE
        for (int i = 0; i <= 2; i++)
        {
            ammo[i].gameObject.SetActive(true);
        }
        ammoAmount = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && !die && rb.velocity.y == 0)
        {
            rb.AddForce(Vector2.up * 500f);
        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 10f;
        }
        else
        {
            moveSpeed = 4;
        }
        setAnimationState();
        if(!die)
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;

        // FIRE

       
        {
            if (Input.GetButtonDown("Fire1") && ammoAmount > 0 && facingRight == false)
            {
                
               
                anim.SetTrigger("GunAttack");
                var spawnedBullet = Instantiate(bullet, barrel.position, barrel.rotation);
                spawnedBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 500);
                ammoAmount -= 1;
                ammo[ammoAmount].gameObject.SetActive(false);
            }
         
           
                if (Input.GetButtonDown("Fire1") && ammoAmount > 0 && facingRight == true)
                {
                
                anim.SetTrigger("GunAttack");
                var spawnedBullet = Instantiate(bullet, BARREl.position, BARREl.rotation);
                    spawnedBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 500);
                    ammoAmount -= 1;
                    ammo[ammoAmount].gameObject.SetActive(false);
                }
          
            
            
        }
       

        
           


            if (Input.GetKey(KeyCode.R))
            {
                ammoAmount = 3;
                for (int i = 0; i <= 2; i++)
                {
                    ammo[i].gameObject.SetActive(true);
                }
            }

        

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
        if (Mathf.Abs(dirX) == 4 && rb.velocity.y == 0)
        {
            anim.SetBool("Run", true);
        }

        if (Input.GetKey(KeyCode.DownArrow) && Mathf.Abs(dirX) == 4)
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
