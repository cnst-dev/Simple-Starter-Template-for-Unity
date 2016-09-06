using ConstantineSpace.Tools;
using UnityEngine;

namespace ConstantineSpace.SimpleUI
{
    public class GameManager : Singleton<GameManager>
    {
        /// <summary>
        /// Initialization.
        /// </summary>
        protected virtual void Start()
        {
            ScreenManager.Instance.SetHomeScreen();
        }

        /// <summary>
        /// Start the level or gameplay.
        /// </summary>
        public virtual void StartLevel()
        {
            ScreenManager.Instance.SetGameScreen();
        }

        /// <summary>
        /// Pause the game.
        /// </summary>
        public virtual void Pause()
        {
            ScreenManager.Instance.SetPauseScreen();
        }

        /// <summary>
        /// Continue the game.
        /// </summary>
        public virtual void UnPause()
        {
            ScreenManager.Instance.HideCurrentScreen();
        }

        /// <summary>
        /// Win the level.
        /// </summary>
        public virtual void WinLevel()
        {
            ScreenManager.Instance.SetWinScreen();
        }

        /// <summary>
        /// Game over.
        /// </summary>
        public virtual void GameOver()
        {
            ScreenManager.Instance.SetGameOverScreen();
        }

        /// <summary>
        /// Restart the game.
        /// </summary>
        public virtual void Restart()
        {
            Debug.Log("Restart game!");
            ScreenManager.Instance.HideCurrentScreen();
        }

        /// <summary>
        /// Go to the Home screen.
        /// </summary>
        public virtual void GoToHome()
        {
            ScreenManager.Instance.HideGameScreen();
            ScreenManager.Instance.SetHomeScreen();
        }

        /// <summary>
        /// Go to the next level.
        /// </summary>
        public virtual void GoToNextLevel()
        {
            Debug.Log("Next level!");
            ScreenManager.Instance.HideCurrentScreen();
        }
    }
}