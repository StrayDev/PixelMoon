using UnityEngine;

namespace PixelMoon.Control
{
    public class AnimationState : MonoBehaviour
    {
        [SerializeField] private Animator anim;
        [SerializeField] private Entity entity;
        
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Direction = Animator.StringToHash("Direction");
        private static readonly int Movement = Animator.StringToHash("Movement");

        private void Update()
        {
            anim.SetFloat(Direction, (float)entity.DirectionState.State);
            anim.SetInteger(Movement, (int)entity.MovementState.State);
        }
    }
}
