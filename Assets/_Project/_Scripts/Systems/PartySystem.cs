using System.Collections.Generic;
using PixelMoon.Control;
using UnityEngine;

namespace PixelMoon.Systems
{
    public class PartySystem : MonoBehaviour
    {
        [SerializeField] private List<Entity> playerParty;
        [SerializeField] private List<Entity> enemyParty;
    
        public List<Entity> PlayerParty => playerParty;
        public List<Entity> EnemyParty => enemyParty;
    
    

    }
}
