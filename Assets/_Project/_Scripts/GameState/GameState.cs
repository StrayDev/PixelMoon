namespace PixelMoon.GameState
{
    public enum States { IsPlaying, InMenu, IsPaused, InBattle };

    public static class GameState
    {
        public static States State { get; private set; } = States.IsPlaying;

        public static bool isPlaying { get; private set; } = true;
        public static bool inMenu    { get; private set; }
        public static bool isPaused  { get; private set; }
        public static bool inBattle  { get; private set; }

        private static States previousState;

        public static void ReturnToPreviousState()
        {
            State = previousState;
            SetBools();
        }

        public static void Set(States state)
        {
            previousState = State;
            State = state;
            SetBools();
        }

        private static void SetBools()
        {
            if (State == States.InMenu)
            {
                inMenu = true;
                isPaused = false;
                isPlaying = false;
                inBattle = false;
            }
            if (State == States.IsPaused)
            {
                inMenu = false;
                isPaused = true;
                isPlaying = false;
                inBattle = false;
            }
            if (State == States.IsPlaying)
            {
                inMenu = false;
                isPaused = false;
                isPlaying = true;
                inBattle = false;
            }
            if (State == States.InBattle)
            {
                inMenu = false;
                isPaused = false;
                isPlaying = false;
                inBattle = true;
            }
        }
    }
}