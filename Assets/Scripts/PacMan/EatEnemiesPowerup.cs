using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EatEnemiesPowerup : BasePowerup
{
    [SerializeField] private float durationOfPowerUp = 3f;

    private AudioSource eatAudio;

    [SerializeField]
    private GameObject ghostList;
    private GhostMovement[] ghostMovementList;

    private CollisionDamageToTargetTag[] damageList;

    [SerializeField] private Material[] ghostMaterials;
    private Renderer[] newGhostMaterials;

    private void Awake()
    {
        eatAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!IsPlayerEntered(other)) return;

        eatAudio.Play();
        FindAllGhosts();
        SetGhostDamage();
        SetGhostMaterials();
        DisablePowerUp();
        ShowNotificationText(notificationMessage); //Show notication text
        Invoke(nameof(EndPowerUp), durationOfPowerUp); // end powerup after duration
    }

    private void EndPowerUp()
    {
        foreach (var ghost in ghostMovementList)
        {
            if (ghost != null)
            {
                ghost.fleeing = false;
            };
        }

        foreach (var ghost in damageList)
        {
            if (ghost != null)
            {
                ghost.damage = 1;
            };
        }

        foreach (var ghost in newGhostMaterials)
        {
            if (ghost != null)
            {
                ghost.materials = new[] { ghostMaterials[Random.Range(0, ghostMaterials.Length - 1)] };
            }
        }

        //ShowNotificationText("Ghosts no longer flee");
        Destroy(gameObject); // Destroy powerup
    }

    private void FindAllGhosts()
    {
        ghostMovementList = ghostList.GetComponentsInChildren<GhostMovement>();

        foreach (var ghost in ghostMovementList)
        {
            ghost.fleeing = true;
        }
    }

    private void SetGhostDamage()
    {
        damageList = ghostList.GetComponentsInChildren<CollisionDamageToTargetTag>();

        foreach (var ghost in damageList)
        {
            ghost.damage = 0;
        }
    }

    private void SetGhostMaterials()
    {
        newGhostMaterials = ghostList.GetComponentsInChildren<Renderer>();

        foreach (var ghost in newGhostMaterials)
        {
            //ghost.material = ghostMaterials[ghostMaterials.Length - 1];
            ghost.materials = new[] { ghostMaterials[ghostMaterials.Length - 1] };
        }
    }
}