using UnityEngine;

public class PlayerProjectileShooter : BaseProjectileShooter
{ 
    private float shootTimer = 0f;
    private AudioSource shootSound;

    private void Awake()
    {
        shootSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (shootTimer > 0)
        {
            // Countdown the shoot timer
            shootTimer -= Time.deltaTime;
        }

        if (Input.GetMouseButton(0) && shootTimer <= 0)
        {
            // Reset the timer
            shootTimer = fireDelay;
            
            // Raycast from the camera to the mouse cursor
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // Use the position of the spawnPosition GameObject as the spawn position
                Vector3 spawnPos = spawnPosition.transform.position;
                
                // Get the direction towards the hit point
                Vector3 direction = (hit.point - spawnPos).normalized;
                
                ShootProjectile(spawnPos, direction);
            }

            shootSound.Play();
        }
    }
}