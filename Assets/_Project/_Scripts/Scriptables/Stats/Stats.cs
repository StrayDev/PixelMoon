using UnityEngine;

namespace PixelMoon.Scriptables.Stats
{
    [CreateAssetMenu(fileName = "new Stats", menuName = "Entity/Stats")]
    public class Stats : ScriptableObject
    {
        [SerializeField] public int Level { get; private set; }

        [SerializeField] [Range(1, 999)] public int Health;
        [SerializeField] [Range(1, 999)] public int MaxHealth;

        [SerializeField] [Range(1, 99)] public int Mana;
        [SerializeField] [Range(1, 99)] public int MaxMana;

        [SerializeField] [Range(1, 99)] public int Strength; 
        [SerializeField] [Range(1, 99)] public int Agility;
        [SerializeField] [Range(1, 99)] public int Perception;
        [SerializeField] [Range(1, 99)] public int Vitality;
        [SerializeField] [Range(1, 99)] public int Potential;

        public int Initiative { get => Level + Agility; }
        public int Damage { get => Level + Strength; }

        public bool TakeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }       

        public void HealDamage()
        {
            Health += (Potential + Vitality); 
        }
    }
}
