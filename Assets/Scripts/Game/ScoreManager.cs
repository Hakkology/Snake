using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _score;

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
        _score += amount;
        Debug.Log("Skor: " + _score);
    }

    private void ResetScore()
    {
        _score = 0;
        Debug.Log("Skor sıfırlandı.");
    }
}