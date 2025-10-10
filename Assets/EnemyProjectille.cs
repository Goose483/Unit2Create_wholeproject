using UnityEngine;

public class EnemyProjectille : MonoBehaviour
{
    // The amount of damage this projectile deals.
    public float damage = 10f;
    public float health = 100f;

    // Called when the projectile collides with another object.
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Projectile hit: " + collision.gameObject.name);

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
