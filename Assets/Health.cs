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
        Debug.Log("Hurt");
        if (!isInvulnerable)
        {
            heartBar.breakHeart(health);
            if (health > 1)
            {
                health -= 1;
                animator.SetTrigger("hurt");
            }
            else
            {
                animator.SetTrigger("death");
                gameLogic.Lose();
            }
            isInvulnerable = true;
            Physics2D.IgnoreLayerCollision(3, 7);
        }
    }


    public void comeBack()
    {
        isInvulnerable = false;
        Physics2D.IgnoreLayerCollision(3, 7, false);
    }


}
