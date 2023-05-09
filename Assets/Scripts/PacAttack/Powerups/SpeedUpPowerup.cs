using UnityEngine;

public class SpeedUpPowerup : BasePowerup
{
    [SerializeField] private float durationOfPowerUp = 2f;
    
    private PlayerMovement playerMovement;

    private void OnTriggerEnter(Collider other)
    {
        if (!IsPlayerEntered(other)) return;

        playerMovement = other.GetComponent<PlayerMovement>();
        if (playerMovement == null) return;

        DisablePowerUp();
        ShowNotificationText(notificationMessage); //Show notication text
        playerMovement.ToggleMovement(); // Toggle control of the player
        Invoke(nameof(EndPowerUp), durationOfPowerUp); // end powerup after duration
    }

    private void EndPowerUp()
    {
        if (playerMovement != null)
        {
            playerMovement.ToggleMovement(); // Toggle player control to normal
            ShowNotificationText("Movement Speed Normal");
        }
        Destroy(gameObject); // Destroy powerup
    }
}