using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Health : MonoBehaviour
{
    public bool dead = false;
    public float health = 100;
    public bool isInvulnerable = false;
    public Animator animator;
    public GameLogic gameLogic;
    
    // Start is called before the first frame update

    public void TakeDamage(float damage) { 
        
        if (isInvulnerable) return;
        health -= damage;
        animator.SetTrigger("Hurt");

        if (health <= 0) Die();
    }

    void Die()
    {
        animator.SetTrigger("Die");
        GetComponent<Collider2D>().enabled = false;
        isInvulnerable = true;
    }

    public void enableInvulnerable()
    {
        isInvulnerable = true;
    }

    public void disableInvulnerable()
    {
        isInvulnerable = false;
    }

    public void ExitWin()
    {
        dead = true;
    }
}
