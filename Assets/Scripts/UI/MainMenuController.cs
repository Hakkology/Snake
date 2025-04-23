using UnityEngine;
using DG.Tweening;

public class MainMenuController : MonoBehaviour
{
    public RectTransform mainMenuPanel;
    public RectTransform settingsPanel;

    public float transitionDuration = 0.5f;

    void Start()
    {
        mainMenuPanel.gameObject.SetActive(true);
        settingsPanel.gameObject.SetActive(false);
    }

    public void OnStartGame()
    {
        GameManager.Instance.SetState(GameState.Playing);
    }

    public void OnSettings()
    {
        mainMenuPanel.DOAnchorPos(new Vector2(-1920, 0), transitionDuration).SetEase(Ease.InOutCubic);
        settingsPanel.gameObject.SetActive(true);
        settingsPanel.DOAnchorPos(Vector2.zero, transitionDuration).SetEase(Ease.InOutCubic);
    }

    public void OnBackFromSettings()
    {
        settingsPanel.DOAnchorPos(new Vector2(1920, 0), transitionDuration).SetEase(Ease.InOutCubic)
            .OnComplete(() => settingsPanel.gameObject.SetActive(false));
        mainMenuPanel.DOAnchorPos(Vector2.zero, transitionDuration).SetEase(Ease.InOutCubic);
    }

    public void OnExitGame()
    {
        Application.Quit();
    }
}
