using UnityEngine;

public class EnemyShooter : MonoBehaviour
{

    public GameObject laser3; // Prefab for the enemy's projectile
    public float projectileSpeed = 20f;
    public Transform firePoint;
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;
    // Optional delay before the first automatic shot (seconds)
    public float initialDelay = 0f;
    public float upwardForce = 5f;
    public AudioClip shootSound;
    // Simple iteration: number of projectiles spawned each time Shoot() runs.
    public int shotsPerFire = 1;
    

    // Update is called once per frame
    void Update()
    {
        // Automatic firing on a timer.
        if (Time.time >= nextFireTime)
        {
            Shoot();
            fireRate = Random.Range(.5f,1f);
        }
    }

    void Shoot()
    {
        // schedule next shot
        nextFireTime = Time.time + fireRate;

        // Basic safety checks
        if (laser3 == null)
        {
            Debug.LogWarning("EnemyShooter: 'laser3' prefab is not assigned.");
            return;
        }

        if (firePoint == null)
        {
            Debug.LogWarning("EnemyShooter: 'firePoint' transform is not assigned.");
            return;
        }

        if (shootSound != null)
        {
            AudioSource.PlayClipAtPoint(shootSound, firePoint.position);
        }

        // Spawn as many projectiles as requested (default 1)
        int count = Mathf.Max(1, shotsPerFire);
        for (int i = 0; i < count; i++)
        {
            GameObject projectile = Instantiate(laser3, firePoint.position, firePoint.rotation);
            Rigidbody2D rb2d = projectile.GetComponent<Rigidbody2D>();
            if (rb2d != null)
            {
                rb2d.gravityScale = 0;
                rb2d.AddForce(Vector2.up * projectileSpeed, ForceMode2D.Impulse);
            }
        }
    }

}
