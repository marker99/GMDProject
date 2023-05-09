using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    
    private int currentHealth;

    public delegate void HealthRemaining(int healthRemaining);
    public event HealthRemaining HealthChanged;

    public delegate void UnitDeath();
    public event UnitDeath IsDead;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        HealthChanged?.Invoke(currentHealth);

        if (currentHealth <= 0)
        {
            IsDead?.Invoke();
            Destroy(gameObject);
        }
    }

    public void Healing(int healing)
    {
        var health = currentHealth + healing;
        if (health > maxHealth)
            currentHealth = maxHealth;
        else
            currentHealth = health;
        HealthChanged?.Invoke(currentHealth);
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }
}