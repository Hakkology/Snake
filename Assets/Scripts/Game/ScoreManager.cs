using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Score;

    private void OnEnable()
    {
        ScoreEvents.OnScoreAdded += AddScore;
        ScoreEvents.OnScoreReset += ResetScore;
    }

    private void OnDisable()
    {
        ScoreEvents.OnScoreAdded -= AddScore;
        ScoreEvents.OnScoreReset -= ResetScore;
    }

    private void AddScore(int amount)
    {
        Score += amount;
        Debug.Log("Skor: " + Score);
    }

    private void ResetScore()
    {
        Score = 0;
        Debug.Log("Skor sıfırlandı.");
    }
}