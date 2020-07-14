using System.Collections;
using UnityEngine;

namespace PixelMoon.Systems.BattleStates
{
    public class Lost : State
    {
        public Lost(BattleSystem battleSystem) : base(battleSystem)
        {
        }

        public override IEnumerator Start()
        {
            Debug.Log("You Lost...");
            yield break;
        }

    }
}



