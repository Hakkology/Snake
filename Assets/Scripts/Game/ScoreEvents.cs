using System;

public static class ScoreEvents
{
    public static event Action<int> OnScoreAdded;
    public static event Action OnScoreReset;

    public static void AddScore(int amount) => OnScoreAdded?.Invoke(amount);
    public static void ResetScore() => OnScoreReset?.Invoke();
}