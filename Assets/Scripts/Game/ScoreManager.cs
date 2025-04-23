using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Score { get; private set; }

    private void Start()
    {
        ResetScore();
    }

    public void AddScore(int amount)
    {
        Score += amount;
        ScoreEvents.UpdateScore(Score);
    }

    public void ResetScore()
    {
        Score = 0;
        ScoreEvents.UpdateScore(Score);
    }
}
