using PixelMoon.Core;
using UnityEngine;

namespace PixelMoon.Systems
{
    public class BattleInput : MonoBehaviour
    {
        [SerializeField] private BattleSystem battleSystem;
        public bool SelectionConfirmed { get; set; } = false;

    void Update()
    {
        if (!GameState.InBattle) return;
            
        int input = (int)Input.GetAxisRaw("Vertical");
        if (input != 0)
        {
            battleSystem.OnSwitchTarget(input);
        }

        if (Input.GetKeyDown(KeyCode.Return))
                BattleSystem.SelectionConfirmed = true;
        }
    }
}
