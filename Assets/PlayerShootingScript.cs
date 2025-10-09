using UnityEngine;

public class PlayerShootingScript : MonoBehaviour
{
    public GameObject laser2;
    public float projectileSpeed = 20f;
    public Transform firePoint;
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;
    public float upwardForce = 5f;
    public AudioClip shootSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Play the shooting sound if there is one
        if (shootSound != null)
        {
            AudioSource.PlayClipAtPoint(shootSound, firePoint.position);
        }

        // Make the laser appear at the fire point
        GameObject projectile = Instantiate(laser2, firePoint.position, firePoint.rotation);

        // Get the Rigidbody2D so we can move it
        Rigidbody2D rb2d = projectile.GetComponent<Rigidbody2D>();

        if (rb2d != null)
        {
            rb2d.gravityScale = 0; // Don't let gravity pull the laser down

            // Make the laser go up
            rb2d.AddForce(Vector2.up * projectileSpeed, ForceMode2D.Impulse);
        }
    }
}
