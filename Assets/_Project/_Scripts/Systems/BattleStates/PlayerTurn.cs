using System.Collections;
using PixelMoon.Control;
using UnityEngine;

namespace PixelMoon.Systems.BattleStates
{
    public class PlayerTurn : State
    {
        private static int _targetIndex;
        private Entity Combatant => BattleSystem.CurrentCombatant;
        private Entity Target { get => BattleSystem.Target; set => BattleSystem.Target = value; }

        public PlayerTurn(BattleSystem battleSystem) : base(battleSystem)
        {
        }

        public override IEnumerator Start()
        {
            Debug.Log($"It is the {Combatant.Name}'s Turn");
            SetLocalValues();
            
            Combatant.MovementState.State = Movement.MOVING;
            while (MovingToPosition(Combatant, AttackPosition, .05f))
            {
                yield return null;
            }
            Combatant.MovementState.State = Movement.IDLE;
            
            yield return new WaitForSeconds(.2f);

            Target = !Target ? BattleSystem.EnemyParty[0] : BattleSystem.EnemyParty[_targetIndex];
            BattleSystem.SelectionIcon.SetPosition(Target.transform.position);
            BattleSystem.BattleMenu.MoveToEntityPosition(Combatant.transform.position);
        }

        public override IEnumerator SwitchTarget(int input)
        {
            _targetIndex = BattleSystem.EnemyParty.IndexOf(Target);
            _targetIndex -= input;
            
            if (_targetIndex < 0) _targetIndex = BattleSystem.EnemyParty.Count -1;
            if (_targetIndex > BattleSystem.EnemyParty.Count -1) _targetIndex = 0;
            
            Target = BattleSystem.EnemyParty[_targetIndex];
            BattleSystem.SelectionIcon.SetPosition(Target.transform.position);
            
            yield return new WaitForSeconds(.2f);
            BattleSystem.switchTargetCoroutine = null;
        }

        public override IEnumerator Attack()
        {
            BattleSystem.BattleMenu.HideMenu();
            
            Debug.Log($"{Combatant.Name} attacks {Target.Name}");

            BattleSystem.SelectionIcon.SetHidden(false);
            BattleSystem.SelectionConfirmed = false;
            while (!BattleSystem.SelectionConfirmed)
            {
                yield return null;
            }
            BattleSystem.SelectionIcon.SetHidden(true);
            yield return new WaitForSeconds(.5f);

            var attackAnimation = AttackAnimation(Combatant, Target);
            while (attackAnimation.MoveNext())
            {
                yield return attackAnimation.Current;
            }

            var isDead = Target.Stats.TakeDamage(Combatant.Stats.Damage);
            yield return new WaitForSeconds(.5f);

            Combatant.DirectionState.State = Side == 1 ? Direction.LEFT : Direction.RIGHT;
            Combatant.MovementState.State = Movement.MOVING;
            while (MovingToPosition(Combatant, BattlePosition, .05f))
            {
                yield return null;
            }
            Combatant.MovementState.State = Movement.IDLE;
            Combatant.DirectionState.State = Side == 1 ? Direction.RIGHT : Direction.LEFT;
            yield return new WaitForSeconds(.5f);

            if (isDead)
            {
                BattleSystem.RemoveDeadCombatant();
                if (!BattleSystem.SetNextValidTarget()) 
                    BattleSystem.SetState(new Won(BattleSystem));  
            }
            
            BattleSystem.StartNextTurn();
        }
        
        private void SetLocalValues()
        {
            var index = BattleSystem.PlayerParty.IndexOf(BattleSystem.CurrentCombatant);
            BattlePosition = BattleSystem.BattleGrid.GetPositionFromIndex(index, true);
            AttackPosition = BattlePosition + new Vector3(2 * Side,0,0);
        }
    }
}



