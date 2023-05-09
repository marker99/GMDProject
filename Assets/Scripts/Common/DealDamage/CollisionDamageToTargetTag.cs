using System.Collections.Generic;
using UnityEngine;

public class CollisionDamageToTargetTag : MonoBehaviour
{
    public int damage;
    [SerializeField] private List<string> tagsToDamageAndSelfDestruct;
    [SerializeField] private List<string> tagsToSelfDestruct;
    [SerializeField] private List<string> tagsToDamage;
    [SerializeField] private bool isTurretBullet = false;
    
    private void OnCollisionEnter(Collision collision)
    {
        HandleCollision(collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        HandleCollision(other.gameObject);
    }

    private void HandleCollision(GameObject collidedObject)
    {
        if (collidedObject == null)
            return;

        string collidedTag = collidedObject.tag;

        if (tagsToDamageAndSelfDestruct.Contains(collidedTag))
        {
            Damage(collidedObject);
            SelfDestruct();
        }
        else if (tagsToSelfDestruct.Contains(collidedTag))
        {
            SelfDestruct();
        }
        else if (tagsToDamage.Contains(collidedTag))
        {
            Damage(collidedObject);
        }
    }
    private void Damage(GameObject targetObject)
    {
        HealthManager health = targetObject.GetComponent<HealthManager>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }

    private void SelfDestruct()
    {
        if(isTurretBullet)
            gameObject.SetActive(false);
        else
            Destroy(gameObject);
    }
}