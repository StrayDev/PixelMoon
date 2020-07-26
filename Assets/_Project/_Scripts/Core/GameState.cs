namespace PixelMoon.Core
{
    public enum GameStates { IsPlaying, InMenu, IsPaused, InBattle };

    public static class GameState
    {
        private static GameStates _gameState = GameStates.IsPlaying;
        private static GameStates _previousGameState;

        public static bool IsPlaying => (_gameState == GameStates.IsPlaying);
        public static bool InMenu => (_gameState == GameStates.InMenu);
        public static bool IsPaused => (_gameState == GameStates.IsPaused);
        public static bool InBattle => (_gameState == GameStates.InBattle);
        
        public static void ReturnToPreviousState()
        {
            _gameState = _previousGameState;
        }

        public static void Set(GameStates gameState)
        {
            _previousGameState = _gameState;
            _gameState = gameState;
        }
    }
}