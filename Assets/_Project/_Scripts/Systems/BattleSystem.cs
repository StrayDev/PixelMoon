using System.Collections.Generic;
using PixelMoon.Control;
using PixelMoon.Scriptables.Stats;
using PixelMoon.Systems.BattleStates;
using UnityEngine;

namespace PixelMoon.Systems
{
    public class BattleSystem : StateMachine
    {
        [SerializeField] private int turn;
        [SerializeField] private Party playerParty;
        [SerializeField] private Party enemyParty; 
        [SerializeField] private List<Entity> combatants;
        [SerializeField] private Entity targetCombatant;
        public Entity TargetCombatant => targetCombatant;
        public Stats TargetStats => TargetCombatant.Stats; 
        public Entity CurrentCombatant => combatants[turn]; 
        public Stats CurrentStats => CurrentCombatant.Stats; 

        private void RollInitiativeOrder()
        {
            combatants.Sort(SortByInitiative);
            turn = 1;
        }

        private int SortByInitiative(Entity a, Entity b)
        {
            if (a.Stats.Initiative > b.Stats.Initiative)
            {
                return -1;
            }
            else if (a.Stats.Initiative < b.Stats.Initiative)
            {
                return 1;
            }
            return 0;
        }

        public void OnBattleTrigger(Party enemies, bool isLeft)
        {
            enemyParty = enemies;

            combatants = new List<Entity>();
            combatants.AddRange(enemyParty.Members);
            combatants.AddRange(playerParty.Members);

            RollInitiativeOrder();

            SetState(new Begin(this));
        }

        public void OnAttackButton()
        {
            StartCoroutine(State.Attack());        
        }

        public void OnHealButton()
        {
            StartCoroutine(State.Heal());
        }

        public void StartNextTurn()
        {
            turn++;

            //increment turn or start a new round
            if (turn == combatants.Count)
            {
                RollInitiativeOrder();
            }

            //create a new state based on if ally or enemy
            if (playerParty.IsPartyMember(CurrentCombatant))
            {
                SetState(new PlayerTurn(this));
            }
            else
            {
                SetState(new EnemyTurn(this));
            }
        }
    }
}
