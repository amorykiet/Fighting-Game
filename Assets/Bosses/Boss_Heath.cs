using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Health : MonoBehaviour
{
    public float health = 100;
    public bool isInvulnerable = false;
    
    // Start is called before the first frame update

    public void TakeDamage(float damage) { 
        
        if (isInvulnerable)
            return;
        health -= damage;

        if (health <= 0)
            Die();
    }

    void Die()
    {
        Physics2D.IgnoreLayerCollision(7, 3, true);
    }

}
