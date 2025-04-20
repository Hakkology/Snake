using System;

public static class HealthEvents
{
    public static event Action<int> OnDamageTaken;
    public static event Action OnHealthReset;

    public static void TakeDamage(int amount) => OnDamageTaken?.Invoke(amount);
    public static void ResetHealth() => OnHealthReset?.Invoke();
}