using System.Collections.Generic;
using System.Net.Configuration;
using PixelMoon.Control;
using PixelMoon.Core;
using PixelMoon.Scriptables.Stats;
using PixelMoon.Systems.BattleStates;
using PixelMoon.UI;
using UnityEngine;

namespace PixelMoon.Systems
{
    public class BattleSystem : StateMachine
    {
        [SerializeField] private BattleMenu battleMenu;
        [SerializeField] private BattleHud battleHud;
        [SerializeField] private BattleGrid battleGrid;
        [SerializeField] private PartySystem partySystem;
        [SerializeField] private SelectionIcon selectionIcon;
        [SerializeField] private int turn;
        [SerializeField] private List<Entity> combatants;
        [SerializeField] private Entity target;
        
        public List<Entity> PlayerParty => partySystem.PlayerParty;
        public List<Entity> EnemyParty => partySystem.EnemyParty;
        public BattleMenu BattleMenu => battleMenu;
        public BattleHud BattleHud => battleHud;
        public BattleGrid BattleGrid => battleGrid;

        public SelectionIcon SelectionIcon => selectionIcon;
        public Entity Target { get => target; set => target = value ; }
        public Stats TargetStats => Target.Stats; 
        public Entity CurrentCombatant => combatants[turn]; 
        public Stats CurrentStats => CurrentCombatant.Stats;
        public bool enemiesOnLeft;
        public static bool SelectionConfirmed;

        public Coroutine switchTargetCoroutine;

        private delegate void SelectedAction();
            
        private static int SortByInitiative(Entity a, Entity b)
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
        
        private void RollInitiativeOrder()
        {
            combatants.Sort(SortByInitiative);
            turn = 0;
        }
        
        public void TriggerBattle(Vector3 origin, bool onLeft)
        {
            enemiesOnLeft = onLeft;
            battleGrid.GeneratePositions(origin, onLeft);
            
            combatants = new List<Entity>();
            combatants.AddRange(PlayerParty);
            combatants.AddRange(EnemyParty);
            
            foreach (var e in combatants)
            {
                if (EnemyParty.Contains(e))
                {
                    e.DirectionState.SetDirectionWithVector(Vector3.right);
                    continue;
                }
                e.DirectionState.SetDirectionWithVector(Vector3.left);
            }
            
            GameState.Set(GameStates.InBattle);
            turn = combatants.Count;
            SetState(new Begin(this));
        }

        public void OnSwitchTarget(int input)
        {
            if (switchTargetCoroutine == null)
                switchTargetCoroutine = StartCoroutine(State.SwitchTarget(input));
        }
        
        public void OnAttackButton()
        {
            StartCoroutine(State.Attack());        
        }
        
        // convert to state?
        public void StartNextTurn()
        {
            turn++;

            //increment turn or start a new round
            if (turn >= combatants.Count)
            {
                RollInitiativeOrder();
            }

            //create a new state based on if ally or enemy
            if (PlayerParty.Contains(CurrentCombatant))
            {
                SetState(new PlayerTurn(this));
            }
            else
            {
                Target = PlayerParty[0];
                //this line should be removed after BS is complete
                selectionIcon.SetPosition(PlayerParty[0].transform.position);
                SetState(new EnemyTurn(this));
            }
        }

        public void RemoveDeadCombatant()
        {
            combatants.Remove(target);
        }

        public bool IsWinCondition()
        {
            foreach (var e in combatants)
            {
             if (EnemyParty.Contains(e))
                 return false;
            }
            return true;
        }
        
        public bool IsLoseCondition()
        {
            foreach (var e in combatants)
            {
                if (PlayerParty.Contains(e))
                    return false;
            }
            return true;
        }
        
        public bool SetNextValidTarget()
        {
            if (EnemyParty.Contains(target))
            {
                foreach (var e in EnemyParty)
                {
                    if (e != target && combatants.Contains(e))
                    {
                        target = e;
                        return true;
                    }
                }
            }
            else
            {
                foreach (var e in PlayerParty)
                {
                    if (e != target && combatants.Contains(e))
                    {
                        target = e;
                        return true;
                    }
                }
            }
            return false;
        }

        public Vector3 GetBattlePosition(Entity entity)
        {
            var inPlayerParty = PlayerParty.Contains(entity);
            return battleGrid.GetPositionFromIndex(PlayerParty.IndexOf(entity), inPlayerParty);
        }
    }
}
