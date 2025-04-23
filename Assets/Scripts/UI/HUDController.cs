using TMPro;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;

    private void OnEnable()
    {
        HealthEvents.OnHealthChanged += SetHealth;
        ScoreEvents.OnScoreChanged += SetScore;
    }

    private void OnDisable()
    {
        HealthEvents.OnHealthChanged -= SetHealth;
        ScoreEvents.OnScoreChanged -= SetScore;
    }

    private void SetHealth(int value)
    {
        healthText.text = $"Can: {value}";
    }

    private void SetScore(int value)
    {
        scoreText.text = $"Skor: {value}";
    }
}
