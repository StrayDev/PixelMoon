using System.Collections;
using UnityEngine;

namespace PixelMoon.Systems.BattleStates
{
    public class Begin : State 
    {
        public Begin(BattleSystem battleSystem) : base(battleSystem)
        {
        }

        public override IEnumerator Start()
        {
            Debug.Log($"A Battle Has Begun");

            yield return new WaitForSeconds(2f);

            BattleSystem.StartNextTurn();
        }
    }
}