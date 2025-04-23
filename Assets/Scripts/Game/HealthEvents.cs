using System;

public static class HealthEvents
{
    public static event Action<int> OnHealthChanged;

    public static void UpdateHealth(int currentHealth)
    {
        OnHealthChanged?.Invoke(currentHealth);
    }
}
