using UnityEngine;

public class ReverseControlPowerup : BasePowerup
{
    [SerializeField] private float durationOfPowerUp = 3f;
    
    private PlayerMovement playerMovement;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!IsPlayerEntered(other)) return;

        playerMovement = other.GetComponent<PlayerMovement>();
        if (playerMovement == null) return;
        
        DisablePowerUp();
        ShowNotificationText(notificationMessage); //Show notication text
        playerMovement.ToggleControl(); // Toggle control of the player
        Invoke(nameof(EndPowerUp), durationOfPowerUp); // end powerup after duration
    }

    private void EndPowerUp()
    {
        if (playerMovement != null)
        {
            playerMovement.ToggleControl(); // Toggle player control to normal
            ShowNotificationText("Movement Normal");
        }
        Destroy(gameObject); // Destroy powerup
    }
}