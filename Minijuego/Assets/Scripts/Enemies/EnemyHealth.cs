using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
    public int health = 1;
    public float invulnPeriod = 0;
    float invulnTimer = 0;
    int correctLayer;
    void Start()
    {
        correctLayer = gameObject.layer;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "laser")
        {
            health--;
            invulnTimer = invulnPeriod;
            gameObject.layer = 10;
        }
    }
    void Update()
    {
        if (invulnTimer > 0)
        {
            invulnTimer -= Time.deltaTime;
            if (invulnTimer <= 0)
            {
                gameObject.layer = correctLayer;
                
            }
        }
        
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
   
}
