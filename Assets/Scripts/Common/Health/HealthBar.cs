using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject gameObject;
    
    private HealthManager healthManager;
    private Slider slider;
    
    private void Start()
    {
        slider = GetComponent<Slider>();
        healthManager = gameObject.GetComponent<HealthManager>();
        healthManager.HealthChanged += SetHealth;
        SetMaxHealth(healthManager.GetMaxHealth());
        SetHealth(healthManager.GetMaxHealth());
    }
    private void SetMaxHealth(int health)
    {
        slider.maxValue = health;
    }

    private void SetHealth(int health)
    {
        slider.value = health;
    }
}