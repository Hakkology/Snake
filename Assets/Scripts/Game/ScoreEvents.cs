using System;

public static class ScoreEvents
{
    public static event Action<int> OnScoreChanged;

    public static void UpdateScore(int newValue)
    {
        OnScoreChanged?.Invoke(newValue);
    }
}