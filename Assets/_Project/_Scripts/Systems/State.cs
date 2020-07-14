using System.Collections;

namespace PixelMoon.Systems
{
    public abstract class State
    {
        protected BattleSystem BattleSystem;

        public State(BattleSystem battleSystem)
        {
            BattleSystem = battleSystem;
        }

        public virtual IEnumerator Start()
        {
            yield break;
        }

        public virtual IEnumerator Attack()
        {
            yield break;
        }

        public virtual IEnumerator Heal()
        {
            yield break;
        }
    }
}
