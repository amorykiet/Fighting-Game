using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Health : MonoBehaviour
{
    public float health = 100;
    public GameObject deathEffect;
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
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Physics2D.IgnoreLayerCollision(3, 7);
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
