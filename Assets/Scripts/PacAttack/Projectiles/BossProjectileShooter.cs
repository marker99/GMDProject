using System.Collections;
using UnityEngine;

public class BossProjectileShooter : BaseProjectileShooter
{ 
    private void Start()
    {
        StartCoroutine(ShootProjectileCoroutine());
    }

    private IEnumerator ShootProjectileCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireDelay);

            Vector3 spawnPos = spawnPosition.transform.position;

            // Find the player object
            GameObject player = GameObject.FindWithTag("Player");

            if (player != null)
            {
                // Calculate the direction towards the player
                Vector3 direction = (player.transform.position - transform.position).normalized;
                
                ShootProjectile(spawnPos, direction);
            }
        }
    }
}