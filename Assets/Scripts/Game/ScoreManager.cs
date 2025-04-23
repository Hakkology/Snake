using UnityEngine;

using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Score { get; private set; }

    public float BaseFixedStep = 0.1f;
    public float MinFixedStep = 0.03f;
    public int ScorePerStep = 50;

    private void Start()
    {
        ResetScore();
    }

    public void AddScore(int amount)
    {
        Score += amount;
        ScoreEvents.UpdateScore(Score);
        UpdateFixedStep();
    }

    public void ResetScore()
    {
        Score = 0;
        ScoreEvents.UpdateScore(Score);
        UpdateFixedStep();
    }

    private void UpdateFixedStep()
    {
        float step = (Score / ScorePerStep) * 0.01f;
        Time.fixedDeltaTime = Mathf.Max(BaseFixedStep - step, MinFixedStep);

        Debug.Log($"[FixedDeltaTime] {Time.fixedDeltaTime:F3}");
    }
}
