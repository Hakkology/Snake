using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 3;
    public int CurrentHealth;

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
        CurrentHealth -= amount;
        Debug.Log("Can: " + CurrentHealth);

        if (CurrentHealth <= 0)
        {
            Debug.Log("Can bitti, oyunu bitiriyoruz.");
            GameManager.Instance.SetState(GameState.MainMenu); 
        }
    }

    private void ResetHealth()
    {
        CurrentHealth = maxHealth;
        Debug.Log("Can sıfırlandı: " + CurrentHealth);
    }
}
