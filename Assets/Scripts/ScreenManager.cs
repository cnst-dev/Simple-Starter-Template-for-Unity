using ConstantineSpace.Tools;
using UnityEngine;

namespace ConstantineSpace.SimpleUI
{
    public class ScreenManager : Singleton<ScreenManager>
    {
        [Header("Screens")]
        [SerializeField]
        private GameObject _startScreen;
        [SerializeField]
        private GameObject _gameScreen;
        [SerializeField]
        private GameObject _pauseScreen;
        [SerializeField]
        private GameObject _gameOverScreen;
        [SerializeField]
        private GameObject _winLevelScreen;


        /// <summary>
		/// Sets the Game screen.
		/// </summary>
		/// <param name="currentScreen"> The current screen game object that will be inactive.</param>
        public virtual void GoToGame(GameObject currentScreen)
        {
            GuiManager.Instance.SetScreenActive(currentScreen, _gameScreen);
        }

        /// <summary>
        /// Sets the Start screen.
        /// </summary>
        /// <param name="currentScreen"> The current screen game object that will be inactive.</param>
        public virtual void GoToStart(GameObject currentScreen)
        {
            if (currentScreen != null)
            {
                GuiManager.Instance.SetScreenInActive(currentScreen);
                GuiManager.Instance.SetScreenInActive(_gameScreen);
            }
            GuiManager.Instance.SetScreenActive(_startScreen);
        }

        /// <summary>
        /// Pauses the game.
        /// </summary>
        public virtual void Pause()
        {
            if (!_pauseScreen.activeInHierarchy)
            {
                GuiManager.Instance.SetScreenActive(_pauseScreen);
            }
        }

        /// <summary>
        /// Unpauses the game.
        /// </summary>
        public virtual void UnPause()
        {
            Debug.Log("UnPause");
            GuiManager.Instance.SetScreenInActive(_pauseScreen);
        }

        /// <summary>
        /// Restarts the game.
        /// </summary>
        /// <param name="currentScreen"> The current screen game object that will be inactive.</param>
        public virtual void Restart(GameObject currentScreen)
        {
            Debug.Log("Restart");
            GuiManager.Instance.SetScreenInActive(currentScreen);
        }

        /// <summary>
        /// Sets the Win screen.
        /// </summary>
        public virtual void WinGame()
        {
            GuiManager.Instance.SetScreenActive(_winLevelScreen);
        }

        /// <summary>
        /// Sets the GameOver screen.
        /// </summary>
        public virtual void GameOver()
        {
            GuiManager.Instance.SetScreenActive(_gameOverScreen);
        }
    }
}