using UnityEngine;

namespace PixelMoon.Control
{
    public enum Direction { UP, DOWN, LEFT, RIGHT }

    public class DirectionState
    {
        public DirectionState() { State = Direction.DOWN; }
        public DirectionState(Direction state) { State = state; }

        public Direction State { get; set; }

        public void SetDirectionWithVector(Vector3 direction)
        {
            if (direction.z > 0)
            {
                State = Direction.UP;
            }
            else if (direction.z < 0)
            {
                State = Direction.DOWN;
            }
            else if (direction.x < 0)
            {
                State = Direction.LEFT;
            }
            else if (direction.x > 0)
            {
                State = Direction.RIGHT;
            }

        }


    }
}