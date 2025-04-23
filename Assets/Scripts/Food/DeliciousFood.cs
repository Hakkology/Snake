using UnityEngine;
using TMPro;

public class DeliciousFood : MonoBehaviour
{
    public float visibleDuration = 5f;
    public float interval = 15f;
    public int scoreAmount = 30;

    public SpriteRenderer spriteRenderer;
    public TextMeshProUGUI timerText; // world-space yazı için
    private float currentTime;
    private bool isActive;

    private void Start()
    {
        spriteRenderer.enabled = false;
        timerText.enabled = false;
        InvokeRepeating(nameof(ActivateObject), interval, interval);
    }

    private void Update()
    {
        if (!isActive) return;

        currentTime -= Time.deltaTime;
        timerText.text = currentTime.ToString("F1") + "s";

        if (currentTime <= 0f)
            DeactivateObject();
    }

    private void ActivateObject()
    {
        transform.position = GetRandomPosition();
        currentTime = visibleDuration;
        isActive = true;
        spriteRenderer.enabled = true;
        timerText.enabled = true;
    }

    private void DeactivateObject()
    {
        isActive = false;
        spriteRenderer.enabled = false;
        timerText.enabled = false;
    }

    private Vector3 GetRandomPosition()
    {
        float x = Mathf.Round(Random.Range(-8f, 8f));
        float y = Mathf.Round(Random.Range(-4f, 4f));
        return new Vector3(x, y, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isActive) return;
        if (other.gameObject.layer == LayerMask.NameToLayer("Snake"))
        {
            DeactivateObject();
        }
    }
}
