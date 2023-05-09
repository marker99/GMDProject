using UnityEngine;

public class TakeDamagePowerup : BasePowerup
{
    [SerializeField] private int damage = 10;
    
    //private AudioSource healAudio;
    
    private void Awake()
    {
        //healAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!IsPlayerEntered(other)) return;


        HealthManager playerHealth = other.gameObject.GetComponent<HealthManager>();
        if (playerHealth == null) return;

        //healAudio.Play(); //Play Audio
        DisablePowerUp(); //Make powerups go invisible
        ShowNotificationText(notificationMessage); //Show notication text
        playerHealth.TakeDamage(damage); //Decrease health
        Invoke(nameof(DestroyObject), 5f); //Destroy after 5s
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}