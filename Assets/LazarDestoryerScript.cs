using UnityEngine;

public class LazarDestoryerScript : MonoBehaviour
{
    public float damage = 100f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            Damageable target = collision.gameObject.GetComponent<Damageable>();
            if (target != null)
            {
                // Call the TakeDamage method on the target.
                target.TakeDamage(damage);
            }
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
