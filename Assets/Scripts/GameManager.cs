using ConstantineSpace.Tools;
using UnityEngine;

namespace ConstantineSpace.SimpleUI
{
    public class GameManager : Singleton<GameManager>
    {
        // All available game states.
        public enum GameState
        {
            Menu,
            InGame,
            Paused
        }
        // The current state of the game.
        public GameState CurrentState { get; private set; }

        /// <summary>
        /// Initialization.
        /// </summary>
        private void Start()
        {
            ScreenManager.Instance.SetHomeScreen();
            SetGameState(GameState.Menu);
        }

        /// <summary>
        /// Start the level or gameplay.
        /// </summary>
        public void StartLevel()
        {
            ScreenManager.Instance.SetGameScreen();
            SetGameState(GameState.InGame);
        }

        /// <summary>
        /// Pause the game.
        /// </summary>
        public void Pause()
        {
            ScreenManager.Instance.SetPauseScreen();
            SetGameState(GameState.Paused);
        }

        /// <summary>
        /// Continue the game.
        /// </summary>
        public void UnPause()
        {
            ScreenManager.Instance.HideCurrentScreen();
            SetGameState(GameState.InGame);
        }

        /// <summary>
        /// Win the level.
        /// </summary>
        public void WinLevel()
        {
            ScreenManager.Instance.SetWinScreen();
            SetGameState(GameState.Menu);
        }

        /// <summary>
        /// Game over.
        /// </summary>
        public void GameOver()
        {
            ScreenManager.Instance.SetGameOverScreen();
            SetGameState(GameState.Menu);
        }

        /// <summary>
        /// Restart the game.
        /// </summary>
        public void Restart()
        {
            Debug.Log("Restart game!");
            ScreenManager.Instance.HideCurrentScreen();
            SetGameState(GameState.InGame);
        }

        /// <summary>
        /// Go to the Home screen.
        /// </summary>
        public void GoToHome()
        {
            ScreenManager.Instance.HideGameScreen();
            ScreenManager.Instance.SetHomeScreen();
            SetGameState(GameState.Menu);
        }

        /// <summary>
        /// Go to the next level.
        /// </summary>
        public void GoToNextLevel()
        {
            Debug.Log("Next level!");
            ScreenManager.Instance.HideCurrentScreen();
            SetGameState(GameState.InGame);
        }

        /// <summary>
        /// Sets the game state.
        /// </summary>
        /// <param name="state">The new sate.</param>
        private void SetGameState(GameState state)
        {
            CurrentState = state;
        }
    }
}