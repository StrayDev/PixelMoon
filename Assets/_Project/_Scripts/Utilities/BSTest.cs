using System;
using UnityEngine;
using PixelMoon.Systems;
using PixelMoon.Control;
using PixelMoon.Core;

namespace PixelMoon.Utilities
{
    public class BSTest : MonoBehaviour
    {
        [SerializeField] private BattleSystem battleSystem;

        void Update()
        {
            if (!Input.GetKeyDown(KeyCode.L)) return;
            
            GameState.Set(GameStates.InBattle);
            battleSystem.TriggerBattle( new Vector3(0f, 1f, 0f), true);
        }
    }
}
