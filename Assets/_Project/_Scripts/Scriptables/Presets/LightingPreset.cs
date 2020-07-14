
using UnityEngine;

namespace PixelMoon.Scriptables.Presets
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "new LightingPreset", menuName = "Lighting/LightingPreset")]
    public class LightingPreset : ScriptableObject
    {
        public Gradient AmbientColour;
        public Gradient DirectionalColour;
        public Gradient FogColour;
    }
}
