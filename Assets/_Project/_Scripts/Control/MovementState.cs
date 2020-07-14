using UnityEngine;

namespace PixelMoon.Control
{
    public enum Movement { IDLE, WALKING, MOVING, SPRINTING }

    public class MovementState 
    {
        public Movement State { get; set; }

        public void CheckMovementModifiers(Vector3 axis, bool sprint, bool walk)
        {
            if (axis == Vector3.zero)
            {
                State = Movement.IDLE;
                return;
            }
            else
            {
                if (sprint)
                {
                    State = Movement.SPRINTING;
                }
                else if (walk)
                {
                    State = Movement.WALKING;
                }
                else
                {
                    State = Movement.MOVING;
                }
            }
        }
    }
}