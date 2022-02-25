using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //MOVE
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

    // Malee Attack
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public Transform attackPoint;
    public int attackDamage = 1;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public int combo = 0;
    //Switch Weapon
    public int Switch = 1;

    // Info Text
    public GameObject InfoSelectSword;
    public GameObject InfoSelectGun;



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
            if (Input.GetMouseButtonDown(0) && ammoAmount > 0 && facingRight == false && Switch == 2)
            {
                
               
                anim.SetTrigger("GunAttack");
                var spawnedBullet = Instantiate(bullet, barrel.position, barrel.rotation);
                spawnedBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 500);
                ammoAmount -= 1;
                ammo[ammoAmount].gameObject.SetActive(false);
            }
         
           
                if (Input.GetMouseButtonDown(0) && ammoAmount > 0 && facingRight == true && Switch == 2)
                {
                
                anim.SetTrigger("GunAttack");
                var spawnedBullet = Instantiate(bullet, BARREl.position, BARREl.rotation);
                    spawnedBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 500);
                    ammoAmount -= 1;
                    ammo[ammoAmount].gameObject.SetActive(false);
                }
            if (Input.GetKey(KeyCode.R))
            {
                ammoAmount = 3;
                for (int i = 0; i <= 2; i++)
                {
                    ammo[i].gameObject.SetActive(true);
                }
            }

        // ATTACK
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0) && Switch == 1)
            {
                combo++;
                if (combo == 1)
                {
                    AttackMalee1();
                    nextAttackTime = Time.time + 1f / attackRate;
                }
                if (combo == 2)
                {
                    AttackMalee2();
                    nextAttackTime = Time.time + 1f / attackRate;
                }
                if (combo == 3)
                {
                    AttackMalee3();
                    nextAttackTime = Time.time + 1f / attackRate;
                    combo = 0;
                }
                combo = Mathf.Clamp(combo, 0, 3);

            }
        }



    }

   public void switch1()
    {
        Switch++;
        if(Switch == 3)
        {
            Switch = 1;
        }
        if (Switch == 2) 
        {
            StartCoroutine("InfoSword");
        }
     
        if (Switch == 1)
        {
            StartCoroutine("InfoGun");
        }
     




    }

    // ATTACK MALEE
    void AttackMalee1()
    {
        anim.SetTrigger("Attack_1");
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemy)
        {
            enemy.GetComponent<MoveEnemy>().TakeHit(attackDamage);


        }
    }
    void AttackMalee2()
    {
        anim.SetTrigger("Attack_2");
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemy)
        {
            enemy.GetComponent<MoveEnemy>().TakeHit(attackDamage);


        }
    }
    void AttackMalee3()
    {
        anim.SetTrigger("Attack_3");
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemy)
        {
            enemy.GetComponent<MoveEnemy>().TakeHit(attackDamage);


        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
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

    public IEnumerator InfoSword()
    {
        InfoSelectGun.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        InfoSelectGun.SetActive(false);
    }
    public IEnumerator InfoGun()
    {
        InfoSelectSword.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        InfoSelectSword.SetActive(false);
    }
}
