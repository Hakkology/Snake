using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Linq;

public class YellowFlashController : MonoBehaviour
{
    [SerializeField] private YellowFlashRendererFeature feature;

    public void Flash(float intensity, float duration)
    {
        if (feature != null)
            StartCoroutine(DoFlash(intensity, duration));
    }

    private IEnumerator DoFlash(float intensity, float duration)
    {
        feature.TriggerFlash(intensity);
        yield return new WaitForSeconds(duration);
        feature.TriggerFlash(0f);
    }
}
