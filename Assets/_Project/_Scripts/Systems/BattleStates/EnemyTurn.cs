using System.Collections.Generic;
using System.Collections;
using PixelMoon.Control;
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
            //BattlePosition = BattleSystem.CurrentCombatant.transform.position;
            //AttackPosition = BattlePosition;
            
            SetLocalValues();
            
            //print the action
            Debug.Log($"{BattleSystem.CurrentCombatant.Name} Attacks {BattleSystem.Target.Name}");
            //wait
            yield return new WaitForSeconds(.5f);
            //deal damage, update hud, check if dead
            var isDead = BattleSystem.TargetStats.TakeDamage(BattleSystem.CurrentStats.Damage);
            
            //update player HUD
            BattleSystem.BattleHud.UpdateHealthBars();

            var attackAnimation = AttackAnimation(BattleSystem.CurrentCombatant, BattleSystem.Target);
            while (attackAnimation.MoveNext())
            {
                yield return attackAnimation.Current;
            }

            yield return new WaitForSeconds(.5f);
            
            if (isDead)
            {
                BattleSystem.SetState(new Lost(BattleSystem));
            }
            else
            {
                BattleSystem.StartNextTurn();
            }
        }
        
        private void SetLocalValues()
        {
            var index = BattleSystem.EnemyParty.IndexOf(BattleSystem.CurrentCombatant);
            BattlePosition = BattleSystem.BattleGrid.GetPositionFromIndex(index, false);
            AttackPosition = BattlePosition;
        }
    }
}



