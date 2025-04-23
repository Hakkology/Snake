using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    private void Start()
    {
        ResetHealth();
    }

    private void TakeDamage(int amount)
    {
        currentHealth -= amount;
        HealthEvents.UpdateHealth(currentHealth);

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
        HealthEvents.UpdateHealth(currentHealth);
        Debug.Log("Can sıfırlandı: " + currentHealth);
    }

    // dışarıdan çağırmak için:
    public void ApplyDamage(int amount)
    {
        TakeDamage(amount);
    }

    public void FullHeal()
    {
        ResetHealth();
    }
}
