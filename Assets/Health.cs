using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Animator animator;
    public int health;
    public HeartBar heartBar;

    bool isInvulnerable;

    private void OnCollisionEnter2D(Collision2D collision)
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
            if (health > 1)
            {
                health -= 1;
                animator.SetTrigger("hurt");
            }
            else
            {
                animator.SetTrigger("death");
            }
            isInvulnerable = true;
            Physics2D.IgnoreLayerCollision(3, 7, true);
        }
    }






    public void comeBack()
    {
        isInvulnerable = false;
        Physics2D.IgnoreLayerCollision(3, 7, false);
    }


}
