using UnityEngine;

namespace PixelMoon.Control
{
    public class AnchorToGround : MonoBehaviour
    {

        [SerializeField, Range(0, -10)] private float distanceToGround = -2.125f;
    
        void Update()
        {
            transform.position = Move.ToFloor(transform.position, distanceToGround);
        }
    }
}
