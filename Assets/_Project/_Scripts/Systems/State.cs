using System.Collections;
using PixelMoon.Control;
using UnityEngine;

namespace PixelMoon.Systems
{
    public abstract class State
    {
        protected BattleSystem BattleSystem;
        protected Vector3 BattlePosition;
        protected Vector3 AttackPosition;
        protected int Side => BattleSystem.enemiesOnLeft ? -1 : 1;

        public State(BattleSystem battleSystem)
        {
            BattleSystem = battleSystem;
        }

        public virtual IEnumerator Start()
        {
            yield break;
        }

        public virtual IEnumerator SwitchTarget(int input)
        {
            yield break;
        }

        public virtual IEnumerator Attack()
        {
            yield break;
        }
        
        protected IEnumerator AttackAnimation(Entity combatant, Entity target)
        {
            var side = BattleSystem.PlayerParty.Contains(combatant) ? Vector3.left : Vector3.right;
            
            var position= combatant.transform.position;
            var enemyPosition = target.transform.position;
            
            while (Vector3.Distance(AttackPosition, position) < 1)
            {
                position = combatant.transform.position;
                var newPosition = Vector3.MoveTowards(position, enemyPosition, .1f);
                combatant.transform.position = newPosition;
                yield return null;
            }
            
            var enemyBattlePosition = target.transform.position;
            while (Vector3.Distance(enemyPosition, enemyBattlePosition) < .1f)
            {
                enemyPosition = target.transform.position;
                var newPosition = Vector3.MoveTowards(enemyPosition, enemyPosition + side, .05f);
                target.transform.position = newPosition;
                yield return null;
            }
            
            while (Vector3.Distance(AttackPosition, position) > 0.05f)
            {
                position = combatant.transform.position;
                var newPosition = Vector3.MoveTowards(position, AttackPosition, .05f);
                combatant.transform.position = newPosition;
                yield return null;
            }
        }

        protected bool MovingToPosition(Entity entity, Vector3 target, float speed)
        {
            var position = entity.transform.position;
            var newPosition = Vector3.MoveTowards(position, target, speed);
            BattleSystem.CurrentCombatant.transform.position = newPosition;

            return Vector3.Distance(position, target) > .05f;
        }

        protected bool MovingToAttackPosition()
        {
            var position = BattleSystem.CurrentCombatant.transform.position;
            var newPosition = Vector3.MoveTowards(position, AttackPosition, .05f);
            BattleSystem.CurrentCombatant.transform.position = newPosition;

            return Vector3.Distance(position, AttackPosition) > .05f;
        }
        
        protected bool MovingToBattlePosition()
        {
            var position = BattleSystem.CurrentCombatant.transform.position;
            var newPosition = Vector3.MoveTowards(position, BattlePosition, .05f);
            BattleSystem.CurrentCombatant.transform.position = newPosition;

            return Vector3.Distance(position, BattlePosition) > .05f;
        }
    }
}
