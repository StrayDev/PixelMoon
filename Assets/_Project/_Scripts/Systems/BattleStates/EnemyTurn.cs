using System.Collections;
using UnityEngine;

namespace PixelMoon.Systems.BattleStates
{
    public class EnemyTurn : State
    {
        public EnemyTurn(BattleSystem battleSystem) : base(battleSystem)
        {
        }

        public override IEnumerator Start()
        {
            //print the action
            Debug.Log($"{BattleSystem.CurrentCombatant.Name} Attacks");
            //wait
            yield return new WaitForSeconds(2f);
            //deal damage, update hud, check if dead
            bool isDead = BattleSystem.TargetStats.TakeDamage(BattleSystem.CurrentStats.Damage);

            //HUD STUFF
            //BattleSystem.playerHud.SetHP(BattleSystem.playerUnit.currentHP);
        
            if (isDead)
            {
                BattleSystem.SetState(new Lost(BattleSystem));
            }
            else
            {
                BattleSystem.StartNextTurn();
            }
        }
    }
}



