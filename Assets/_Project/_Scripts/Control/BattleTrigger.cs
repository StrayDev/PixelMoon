using PixelMoon.Core;
using UnityEngine;

namespace PixelMoon.Control
{
    public class BattleTrigger : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                GameState.Set(GameStates.InBattle);
            }
        }
    }
}
