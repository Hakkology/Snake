using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    public HealthManager healthManager;
    public ScoreManager scoreManager;

    private void OnEnable()
    {
        HealthEvents.OnDamageTaken += UpdateHealthText;
        HealthEvents.OnHealthReset += UpdateHealthText;

        ScoreEvents.OnScoreReset += UpdateScoreText;
        ScoreEvents.OnUpdateScore += UpdateScoreText;
    }

    private void OnDisable()
    {
        HealthEvents.OnDamageTaken -= UpdateHealthText;
        HealthEvents.OnHealthReset -= UpdateHealthText;

        ScoreEvents.OnScoreReset -= UpdateScoreText;
        ScoreEvents.OnUpdateScore -= UpdateScoreText;
    }

    private void Start()
    {
        UpdateHealthText();
        UpdateScoreText();
    }

    private void UpdateHealthText(int _ = 0)
    {
        healthText.text = $"Can: {healthManager.CurrentHealth}";
    }

    private void UpdateScoreText(int _ = 0)
    {
        scoreText.text = $"Skor: {scoreManager.Score}";
    }
}
