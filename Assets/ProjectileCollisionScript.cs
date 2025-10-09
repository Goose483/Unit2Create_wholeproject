using UnityEngine;

public class ProjectileCollisionScript : MonoBehaviour
{
    // The amount of damage this projectile deals.
    public float damage = 10f;

    // Called when the projectile collides with another object.
    void OnCollisionEnter2D(Collision2D collision)
    {
        /*Debug.Log("Projectile hit: Enemy " + collision.gameObject.name);

        Damageable target = collision.gameObject.GetComponent<Damageable>();
        if (target != null)
        {
            // Call the TakeDamage method on the target.
            target.TakeDamage(damage);
        }

        // Destroy this projectile after hitting something.
        Destroy(gameObject);*/
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Projectile hit: Enemy " + collision.gameObject.name);

            Damageable target = collision.gameObject.GetComponent<Damageable>();
            if (target != null)
            {
                // Call the TakeDamage method on the target.
                target.TakeDamage(damage);
            }

            // Destroy this projectile after hitting something.
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
