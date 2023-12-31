using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Run : StateMachineBehaviour
{
    public float lastAttackTime = 0f;
    public float attackTimeGap = 3f;
    public float speed = 2.5f;
    public float attackRange = 3f;
    public PlayerHealth playerHealth;

    Transform player;
    Rigidbody2D rb;
    Boss boss;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(playerHealth.health <= 0)
        {
            animator.SetTrigger("Idle");
            return;
        }

        boss.lookAtPlayer();
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
        
        if (Vector2.Distance(player.position, rb.position) < attackRange) 
        {
            if (Time.time - lastAttackTime > attackTimeGap)
            {
                attackTimeGap = Random.Range(1.0f, 3.0f);
                animator.SetTrigger("Attack");
                lastAttackTime = Time.time;
            }
        }

    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }

}  
    

