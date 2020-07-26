using System;
using PixelMoon.Scriptables.Stats;
using UnityEngine;

namespace PixelMoon.UI
{
    public class BarScaler : MonoBehaviour
    {
        [SerializeField] private Stats stats;

        private void Update()
        {
            transform.localScale = new Vector3((stats.Health/(float)stats.MaxHealth), 1f); 
        }
    }
}
