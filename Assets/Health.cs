using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Animator animator;

    public int health;
    bool isInvulnerable;
    // Start is called before the first frame update
    void Start()
    {
        health = 5;
    }

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
            if (health > 1)
            {
                health -= 1;
                Debug.Log("Hurt");
                animator.SetTrigger("hurt");
            }
            else
            {
                Debug.Log("Death");
                animator.SetTrigger("death");
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
