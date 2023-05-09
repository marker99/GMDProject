using UnityEngine;
using UnityEngine.Serialization;

public class TurretShootProjectiles: MonoBehaviour
{
    [SerializeField] private int projectileAmount = 3;
    [SerializeField] private float projectileSpeed = 3f;
    [SerializeField] private float startAngle = 140f, endAngle = 0f;
    
    void Start()
    {
        InvokeRepeating("Fire", 0f, 2f);
    }

    private void Fire()
    {
        float angleSpread = (endAngle - startAngle) / projectileAmount;
        float angle = startAngle;

        Quaternion objectRotation = transform.rotation;

        for (int i = 0; i < projectileAmount; i++)
        {
            float projectileDirectionX = Mathf.Cos((angle * Mathf.PI) / 180f);
            float projectileDirectionZ = Mathf.Sin((angle * Mathf.PI) / 180f);

            Vector3 projectileDirection = new Vector3(projectileDirectionX, 0f, projectileDirectionZ).normalized;

            // Apply the angle of the GameObject to the bullet direction
            projectileDirection = objectRotation * projectileDirection;

            // Shoot the projectile
            ShootProjectileFromPool(projectileDirection);

            angle += angleSpread;
        }
    }
    
    private void ShootProjectileFromPool(Vector3 projectileDirection)
    {
        GameObject bullet = TurretBulletPool.instance.GetBullet();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
        bullet.SetActive(true);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.AddForce(projectileDirection * projectileSpeed, ForceMode.Impulse);
        
        //Rotate bullet to face direction shot
        bullet.transform.LookAt(bullet.transform.position + projectileDirection);
    }

}