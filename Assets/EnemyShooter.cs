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
    

    // Update is called once per frame
    void Update()
    {
        // Automatic firing on a timer (no player input required).
        if (Time.time >= nextFireTime)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // schedule next shot
        nextFireTime = Time.time + fireRate;
        // Play the shooting sound if there is one
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

        // Make the laser appear at the fire point
        GameObject projectile = Instantiate(laser3, firePoint.position, firePoint.rotation);

        // Get the Rigidbody2D so we can move it
        Rigidbody2D rb2d = projectile.GetComponent<Rigidbody2D>();

        if (rb2d != null)
        {
            rb2d.gravityScale = 0; // Don't let gravity pull the laser down

            // Make the laser go up
            rb2d.AddForce(Vector2.down * projectileSpeed, ForceMode2D.Impulse);
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Ensure fireRate is positive to avoid zero/negative spam or instant-firing
        if (fireRate <= 0f)
        {
            Debug.LogWarning("EnemyShooter: 'fireRate' must be > 0. Defaulting to 0.5f.");
            fireRate = 0.5f;
        }

        // Schedule first shot after optional initial delay
        nextFireTime = Time.time + initialDelay;
    }

}
