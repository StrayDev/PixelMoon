using UnityEngine;
using PixelMoon.Systems;

namespace PixelMoon.Utilities
{
    public class BSTest : MonoBehaviour
    {
        [SerializeField] private Party enemies;
        [SerializeField] private BattleSystem battleSystem;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                battleSystem.OnBattleTrigger(enemies, true);
            }
        
        }
    }
}
