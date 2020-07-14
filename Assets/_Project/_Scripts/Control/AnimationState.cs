using UnityEngine;

namespace PixelMoon.Control
{
    public class AnimationState : MonoBehaviour
    {
        [SerializeField] private Animator anim;
        [SerializeField] private Entity entity;

        private void Update()
        {
            anim.SetFloat("Direction", (float)entity.DirectionState.State);
            anim.SetInteger("Movement", (int)entity.MovementState.State);
        }
    }
}
