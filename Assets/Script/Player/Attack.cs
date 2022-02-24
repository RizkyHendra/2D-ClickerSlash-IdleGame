using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator animator;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public Transform attackPoint;
    public int attackDamage = 1;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    public int combo = 0;
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
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

    void AttackMalee1()
    {
        animator.SetTrigger("Attack_1");
        Collider2D[] hitEnemy =  Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemy)
        {
            enemy.GetComponent<MoveEnemy>().TakeHit(attackDamage);


        }
    }
    void AttackMalee2()
    {
        animator.SetTrigger("Attack_2");
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemy)
        {
            enemy.GetComponent<MoveEnemy>().TakeHit(attackDamage);


        }
    }
    void AttackMalee3()
    {
        animator.SetTrigger("Attack_3");
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
}
