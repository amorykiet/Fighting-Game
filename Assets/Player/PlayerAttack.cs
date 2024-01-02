using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float timeBtwAttack;
    float timeCouter;
    public Animator animator;
    public LayerMask whatIsEnermy;
    public Transform attackDownCheck;
    public float damage;
    public PlayerMovement movement;

    [Header("Attack Horizontal")]
    public Transform attackHorizontalPos;
    public float attackHorizontalRangeX;
    public float attackHorizontalRangeY;


    [Header("Attack Up")]
    public Transform attackUpPos;
    public float attackUpRangeX;
    public float attackUpRangeY;


    [Header("Attack Down")]
    public Transform attackDownPos;
    public float attackDownRangeX;
    public float attackDownRangeY;
    Collider2D[] enemisToDamage;

    bool canAttackDown;

    void Update()
    {
        canAttackDown = !Physics2D.OverlapCircle(attackDownCheck.position, 0.1f);
        if (timeCouter <= 0)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    animator.SetTrigger("attack up");
                    enemisToDamage = Physics2D.OverlapBoxAll (attackUpPos.position, new Vector2( attackUpRangeX, attackUpRangeY), 0, whatIsEnermy);
                    for (int i = 0; i < enemisToDamage.Length; i++)
                    {
                        enemisToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                    }
                }
                else if (Input.GetKey(KeyCode.DownArrow) && canAttackDown)
                {
                    animator.SetTrigger("attack down");
                    enemisToDamage = Physics2D.OverlapBoxAll(attackDownPos.position, new Vector2(attackDownRangeX, attackDownRangeY), 0, whatIsEnermy);
                    for (int i = 0; i < enemisToDamage.Length; i++)
                    {
                        enemisToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                        if (i == 0)
                        {
                            movement.jumpWithAttack();
                        }
                    }
                }
                else
                {
                    animator.SetInteger("attack horizontal index", Random.Range(0, 2));
                    animator.SetTrigger("attack horizontal");
                    enemisToDamage = Physics2D.OverlapBoxAll(attackHorizontalPos.position, new Vector2(attackHorizontalRangeX, attackHorizontalRangeY), 0, whatIsEnermy);
                    for (int i = 0; i < enemisToDamage.Length; i++)
                    {
                        enemisToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                    }
                }
                timeCouter = timeBtwAttack;
            }
        }
        else
        {
            timeCouter -= Time.deltaTime;
        }
    }
 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackHorizontalPos.position, new Vector2(attackHorizontalRangeX, attackHorizontalRangeY));
        //Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(attackUpPos.position, new Vector2(attackUpRangeX, attackUpRangeY));
        Gizmos.DrawWireCube(attackDownPos.position, new Vector2(attackDownRangeX, attackDownRangeY));
    }
}
