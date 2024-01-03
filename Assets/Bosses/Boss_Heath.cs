using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Health : MonoBehaviour
{
    public float health = 100;
    public bool isInvulnerable = false;
    public Animator animator;
    
    // Start is called before the first frame update

    public void TakeDamage(float damage) { 
        
        if (isInvulnerable)
            return;
        health -= damage;
        
        animator.SetTrigger("Hurt");
        if (health <= 0)
            Die();
    }

    void Die()
    {
        Debug.Log("Die");
        GetComponent<Collider2D>().enabled = false;
        isInvulnerable = true;
    }

}
