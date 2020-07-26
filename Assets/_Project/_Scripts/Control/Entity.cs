using PixelMoon.Core;
using PixelMoon.Scriptables.Behaviours;
using PixelMoon.Scriptables.Stats;
using PixelMoon.Scriptables.Variables;
using UnityEngine;

namespace PixelMoon.Control
{
    public class Entity : MonoBehaviour
    {     
        [SerializeField] private Rigidbody rb;
        [SerializeField] private EntityController controller;
        [SerializeField] private FloatValue speed;
        [SerializeField] private Stats stats;

        public Rigidbody Rb => rb;
        public EntityController Controller { get => controller; set => controller = value; }
        public Stats Stats => stats;
        public float Speed => speed.Value; 
        public string Name => gameObject.name; 
        public DirectionState DirectionState { get; private set; }
        public MovementState MovementState { get; private set; }

        private void Start()
        {
            if (stats.isTemplate)
            {
                stats = Instantiate(stats);
            }
            DirectionState = new DirectionState();
            MovementState = new MovementState();
        }

        private void Update()
        {
            if (controller && GameState.IsPlaying)
            {
                controller.Use(this);
            }
        }
    }
}
