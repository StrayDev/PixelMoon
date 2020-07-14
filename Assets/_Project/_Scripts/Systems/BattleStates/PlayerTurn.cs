using System.Collections;
using UnityEngine;

namespace PixelMoon.Systems.BattleStates
{
    public class PlayerTurn : State
    {
        public PlayerTurn(BattleSystem battleSystem) : base(battleSystem)
        {
        }

        public override IEnumerator Start()
        {
            Debug.Log("It is the players Turn");
            yield break;
        }

        public override IEnumerator Attack()
        {
            Debug.Log("You Attack");

            bool isDead = BattleSystem.TargetStats.TakeDamage(BattleSystem.CurrentStats.Damage);

            //HUD STUFF
            //BattleSystem.enemyHud.SetHP(BattleSystem.enemyUnit.currentHP);

            yield return new WaitForSeconds(2f);

            if (isDead)
            {
                BattleSystem.SetState(new Won(BattleSystem));    
            }
            else
            {
                BattleSystem.StartNextTurn();
            }        
        }

        public override IEnumerator Heal()
        {
            Debug.Log($"You heal");

            BattleSystem.CurrentStats.HealDamage();
        
            //HUD STUFF 
            //BattleSystem.playerHud.SetHP(BattleSystem.playerUnit.currentHP);

            yield return new WaitForSeconds(2f);

            BattleSystem.StartNextTurn();
        }
    }
}



