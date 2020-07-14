using PixelMoon.Scriptables.Behaviours;
using PixelMoon.Scriptables.Stats;
using PixelMoon.Scriptables.Variables;
using UnityEngine;

namespace PixelMoon.Control
{
    public class Entity : MonoBehaviour
    {     
        [SerializeField] private Animator anim;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private EntityController controller;
        [SerializeField] private FloatValue speed;
        [SerializeField] private Stats stats;

        public EntityController Controller { get; set; }
        public Stats Stats => stats;

        public float Speed => speed.Value; 
        public string Name => gameObject.name; 
        public DirectionState DirectionState { get; private set; }
        public MovementState MovementState { get; private set; }

        private void Start()
        {
            DirectionState = new DirectionState();
            MovementState = new MovementState();
        }

        private void Update()
        {
            if (controller && GameState.GameState.isPlaying)
            {
                controller.Use(this);
            }
        }
    }
}
