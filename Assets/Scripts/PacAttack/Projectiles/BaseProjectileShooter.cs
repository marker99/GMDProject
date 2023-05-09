using UnityEngine;

public abstract class BaseProjectileShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject spawnPosition;
    public float fireDelay = 1f;
    public float bulletSpeed = 5f;

    protected void ShootProjectile(Vector3 spawnPos, Vector3 direction)
    {
        GameObject bullet = InstantiateProjectile(spawnPos);

        ApplyForce(bullet, direction);
    }

    protected GameObject InstantiateProjectile(Vector3 spawnPos)
    {
        return Instantiate(projectilePrefab, spawnPos, Quaternion.identity);
    }

    protected void ApplyForce(GameObject projectile, Vector3 direction)
    {
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(direction * bulletSpeed, ForceMode.Impulse);

        // Rotate the bullet to face the direction it's moving in
        projectile.transform.LookAt(projectile.transform.position + direction);
    }
}