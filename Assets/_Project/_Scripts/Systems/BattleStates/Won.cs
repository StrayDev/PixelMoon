using System.Collections;
using UnityEngine;

namespace PixelMoon.Systems.BattleStates
{
    public class Won : State
    {
        public Won(BattleSystem battleSystem) : base(battleSystem)
        {
        }

        public override IEnumerator Start()
        {
            Debug.Log("You Won!");
            yield break;
        }

    }
}



