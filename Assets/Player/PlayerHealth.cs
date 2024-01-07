using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Animator animator;
    public int health;
    public HeartBar heartBar;
    public GameLogic gameLogic;
    public GameObject Hollow;

    public float timeRecover = 5;
    public float timeCouter;

    bool isInvulnerable;
    bool exitedBoss = true;
    bool isDead;
    Transform playerPos;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isDead) { return; }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Hurt();
            exitedBoss = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        exitedBoss = true;
    }
    private void Start()
    {
        timeCouter = timeRecover;
        exitedBoss = true;
        isDead = false;
        playerPos = GetComponent<Transform>();
    }

    private void Update()
    {
        if(isDead) { return; }
        if (isInvulnerable) 
        {
            if (timeCouter > 0) 
            {
                timeCouter -= Time.deltaTime;
            }
            else
            {
                timeCouter = timeRecover;
                isInvulnerable = false;
                if (!exitedBoss)
                {
                    Hurt();
                }
            }
        }
    }

    public void Hurt()
    {
        if(isInvulnerable) { return; }
        heartBar.breakHeart(health);
        health -= 1;
        if (health > 0)
        {
            animator.SetTrigger("hurt");
        }
        else
        {
            exitedBoss = true;
            animator.SetTrigger("death");
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            gameObject.GetComponent<PlayerAttack>().canAttack = false;
            gameObject.GetComponent<PlayerMovement>().canRun = false;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            isDead = true;
        }
        isInvulnerable = true;

    }

    public void HollowFall()
    {
        Instantiate(Hollow, playerPos);
    }

    public void exitLose()
    {
        gameLogic.Lose();
    }
}
