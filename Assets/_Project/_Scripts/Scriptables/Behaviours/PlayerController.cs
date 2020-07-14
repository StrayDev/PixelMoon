using PixelMoon.Control;
using UnityEngine;

namespace PixelMoon.Scriptables.Behaviours
{
    [CreateAssetMenu(fileName = "new PlayerController", menuName = "EntityController/PlayerController")]
    public class PlayerController : EntityController
    {
        public override void Use(Entity entity)
        {
            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

            entity.DirectionState.SetDirectionWithVector(input);
            entity.MovementState.CheckMovementModifiers(input, Input.GetKey(KeyCode.LeftShift), Input.GetKey(KeyCode.LeftControl));

            Move.WithVelocity(entity.GetComponent<Rigidbody>(), CurrentSpeed(entity), input);
        }

        private float CurrentSpeed(Entity entity)
        {
            return entity.Speed * (int)entity.MovementState.State;
        }
    }
}
