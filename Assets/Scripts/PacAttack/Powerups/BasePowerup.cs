using System.Collections;
using TMPro;
using UnityEngine;

public class BasePowerup : MonoBehaviour
{    
    [SerializeField] private float durationBeforeDestroyed = 8f;
    public string notificationMessage;

    private Renderer powerUpRenderer;
    private Collider powerUpCollider;
    private TMP_Text notificationText;

    protected virtual void Start()
    {
        powerUpRenderer = GetComponent<Renderer>();
        powerUpCollider = GetComponent<Collider>();
        Invoke(nameof(TimeoutDestroy), durationBeforeDestroyed);

        notificationText = GameObject.Find("PowerupText").GetComponent<TMP_Text>();
    }

    protected void DisablePowerUp()
    {
        powerUpRenderer.enabled = false; // Disable the power-up's renderer
        powerUpCollider.enabled = false; // Disable the power-up's collider
    }

    protected virtual void OnDestroy()
    {
        powerUpRenderer.enabled = true; // Enable the power-up's renderer when destroyed
        powerUpCollider.enabled = true; // Enable the power-up's collider when destroyed
    }

    protected void TimeoutDestroy()
    {
        if(powerUpRenderer.enabled )
            Destroy(gameObject);
    }

    protected bool IsPlayerEntered(Collider other)
    {
        return other.CompareTag("Player");
    }

    protected void ShowNotificationText(string notificationMessage)
    {
        notificationText.text = notificationMessage;
        StartCoroutine(HideNotificationText());
    }

    protected IEnumerator HideNotificationText()
    {
        yield return new WaitForSeconds(1.5f);
        notificationText.text = "";
    }

}