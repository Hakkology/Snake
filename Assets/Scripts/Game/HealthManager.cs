using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    private void OnEnable()
    {
        HealthEvents.OnDamageTaken += TakeDamage;
        HealthEvents.OnHealthReset += ResetHealth;
    }

    private void OnDisable()
    {
        HealthEvents.OnDamageTaken -= TakeDamage;
        HealthEvents.OnHealthReset -= ResetHealth;
    }

    private void Start()
    {
        ResetHealth();
    }

    private void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Can: " + currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("Can bitti, oyunu bitiriyoruz.");
            GameManager.Instance.SetState(GameState.MainMenu); 
        }
    }

    private void ResetHealth()
    {
        currentHealth = maxHealth;
        Debug.Log("Can sıfırlandı: " + currentHealth);
    }
}
