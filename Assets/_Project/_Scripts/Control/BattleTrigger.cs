using PixelMoon.GameState;
using UnityEngine;

namespace PixelMoon.Control
{
    public class BattleTrigger : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                GameState.GameState.Set(States.InBattle);
            }
        }
    }
}
