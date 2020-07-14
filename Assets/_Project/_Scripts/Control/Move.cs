using UnityEngine;

namespace PixelMoon.Control
{
    public static class Move
    {
        public static void WithVelocity(Rigidbody rb, float speed, Vector3 direction)
        {
            //store Y velocity
            float maintainY = rb.velocity.y;

            //Get input and normalise
            direction.Normalize();

            //apply input and speed to the rb then restore the y
            rb.velocity = direction * speed;
            rb.velocity = new Vector3(rb.velocity.x, maintainY, rb.velocity.z);
        }

        public static Vector3 ToFloor(Vector3 position, float offset)
        {
            Ray ray = new Ray(position, Vector3.down);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, ~8))
            {
                if (hit.point.y < position.y + offset - 0.05)
                {
                    //float offset = transform.position.y - floorOffset;
                    position = new Vector3(position.x, hit.point.y - offset, position.z);
                }
            }
            return position;
        }
    }
}
