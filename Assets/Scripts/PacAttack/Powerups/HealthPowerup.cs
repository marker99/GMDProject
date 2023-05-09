using UnityEngine;

public class HealthPowerup : BasePowerup
{
    [SerializeField] private int healthIncrease = 20;
    
    private AudioSource healAudio;

    private void Awake()
    {
        healAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!IsPlayerEntered(other)) return;
        

        HealthManager playerHealth = other.gameObject.GetComponent<HealthManager>();
        if (playerHealth == null) return;
            
        healAudio.Play(); //Play Audio
        playerHealth.Healing(healthIncrease); //Increase health
        DisablePowerUp(); //Make powerups go invisible
        ShowNotificationText(notificationMessage); //Show notication text
        Invoke(nameof(DestroyObject), 5f); //Destroy after 5s
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}