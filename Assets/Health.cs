using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Animator animator;
    public int health;
    public HeartBar heartBar;
    public GameLogic gameLogic;

    bool isInvulnerable;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Hurt();
        }
    }


    public void Hurt()
    {
        if (!isInvulnerable)
        {
            heartBar.breakHeart(health);
            health -= 1;
            if (health > 0)
            {
                animator.SetTrigger("hurt");
            }
            else
            {
                animator.SetTrigger("death");
                gameLogic.Lose();
                gameObject.GetComponent<PlayerAttack>().canAttack = false;
                gameObject.GetComponent<PlayerMovement>().canRun = false;
            }
            isInvulnerable = true;
        }
    }


    public void comeBack()
    {
        isInvulnerable = false;
    }


}
