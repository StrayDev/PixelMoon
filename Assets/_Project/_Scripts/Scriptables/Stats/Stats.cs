using UnityEngine;

namespace PixelMoon.Scriptables.Stats
{
    [CreateAssetMenu(fileName = "new Stats", menuName = "Entity/Stats")]
    public class Stats : ScriptableObject
    {
        [SerializeField] public bool isTemplate;
        
        [SerializeField] [Range(1, 999)] public int Level;

        [SerializeField] [Range(1, 999)] public int Health;
        [SerializeField] [Range(1, 999)] public int MaxHealth;

        [SerializeField] [Range(1, 99)] public int Mana;
        [SerializeField] [Range(1, 99)] public int MaxMana;

        [SerializeField] [Range(1, 99)] public int Strength; 
        [SerializeField] [Range(1, 99)] public int Agility;
        [SerializeField] [Range(1, 99)] public int Perception;
        [SerializeField] [Range(1, 99)] public int Vitality;
        [SerializeField] [Range(1, 99)] public int Potential;

        public int Initiative => Level + Agility; 
        public int Damage => Level + Strength; 

        public bool TakeDamage(int damage)
        {
            Health -= damage;
            return Health <= 0;
        }       

        public void HealDamage()
        {
            Health += (Potential + Vitality); 
        }
    }
}
