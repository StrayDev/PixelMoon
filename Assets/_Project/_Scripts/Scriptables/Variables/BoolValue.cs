using UnityEngine;

namespace PixelMoon.Scriptables.Variables
{
    [CreateAssetMenu(fileName = "new BoolValue", menuName = "Values/BoolValue")]
    public class BoolValue : ScriptableObject
    {
        [SerializeField] public bool Value { get; set; }
    }
}
