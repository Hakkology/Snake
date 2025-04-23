using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class YellowFlashRendererFeature : ScriptableRendererFeature
{
    class YellowFlashPass : ScriptableRenderPass
    {
        public Material overlayMat;
        public float intensity;

        public YellowFlashPass() => renderPassEvent = RenderPassEvent.AfterRendering;
        
        public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
        {
            ConfigureTarget(BuiltinRenderTextureType.CameraTarget);
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            // Debug.Log("Execute() tetiklendi");

            if (overlayMat == null || intensity <= 0f) return;

            // Debug.Log($"Yellow Flash çalışıyor: {intensity}");

            CommandBuffer cmd = CommandBufferPool.Get("Yellow Flash");
            overlayMat.SetColor("_Color", new Color(1f, 1f, 0f, intensity));
            cmd.Blit(null, BuiltinRenderTextureType.CameraTarget, overlayMat);
            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }

    }

    [System.Serializable]
    public class Settings
    {
        public Material overlayMaterial;
    }

    public Settings settings = new();
    YellowFlashPass _pass;

    public override void Create()
    {
        _pass = new YellowFlashPass { overlayMat = settings.overlayMaterial };
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        _pass.overlayMat = settings.overlayMaterial;

        renderer.EnqueuePass(_pass);
    }

    public void TriggerFlash(float intensity)
    {
        _pass.intensity = intensity;
    }
}
