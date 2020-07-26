using PixelMoon.Core;
using PixelMoon.Scriptables.Presets;
using UnityEngine;

namespace PixelMoon.Systems
{
    [ExecuteAlways]
    public class LightingSystem : MonoBehaviour
    {
        [SerializeField] private Light DirectionalLight;
        [SerializeField] private LightingPreset Preset;

        [SerializeField, Range(0, 24)] private float TimeOfDay;
        [SerializeField] private float TimeSpeed = 1;

        private void Update()
        {
            if (!Preset) return;
        
            if (GameState.IsPlaying && Application.isPlaying)
            {
                TimeOfDay += Time.deltaTime * TimeSpeed;
                TimeOfDay %= 24; //Clamps between 0-24
            }
            UpdateLighting(TimeOfDay / 24);

        }

        private void UpdateLighting(float timePercent)
        {
            RenderSettings.ambientLight = Preset.AmbientColour.Evaluate(timePercent);
            RenderSettings.fogColor = Preset.FogColour.Evaluate(timePercent);

            if (DirectionalLight != null)
            {
                DirectionalLight.color = Preset.DirectionalColour.Evaluate(timePercent);
                DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 50f, 10));
            }
        }

        private void OnValidate()
        {
            if (DirectionalLight != null) { return; }

            if (RenderSettings.sun != null)
            {
                DirectionalLight = RenderSettings.sun;
            }
            else
            {
                Light[] lights = GameObject.FindObjectsOfType<Light>();
                foreach (Light light in lights)
                {
                    if (light.type == LightType.Directional)
                    {
                        DirectionalLight = light;
                        return;
                    }
                }
            }
        }
    }
}
