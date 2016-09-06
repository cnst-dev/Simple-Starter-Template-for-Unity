using ConstantineSpace.Tools;
using UnityEngine;

namespace ConstantineSpace.SimpleUI
{
    public class ScreenManager : Singleton<ScreenManager>
    {
        [Header("Screens")]
        [SerializeField]
        private GameObject _homeScreen;
        [SerializeField]
        private GameObject _gameScreen;
        [SerializeField]
        private GameObject _pauseScreen;
        [SerializeField]
        private GameObject _gameOverScreen;
        [SerializeField]
        private GameObject _winLevelScreen;

        // The current screen game object.
        public GameObject _currentScreen;

        /// <summary>
        /// Sets the Start screen.
        /// </summary>
        public virtual void SetHomeScreen()
        {
            GuiManager.Instance.SetScreenActive(_homeScreen);
            if (_currentScreen != null)
            {
                HideCurrentScreen();
            }
            _currentScreen = _homeScreen;
        }

        /// <summary>
        /// Sets the Game screen.
        /// </summary>
        public virtual void SetGameScreen()
        {
            HideCurrentScreen();
            GuiManager.Instance.SetScreenActive(_gameScreen);
            _currentScreen = _gameScreen;
        }

        /// <summary>
        /// Hides the Game screen.
        /// </summary>
        public virtual void HideGameScreen()
        {
            GuiManager.Instance.SetScreenInActive(_gameScreen);
        }

        /// <summary>
        /// Pauses the game.
        /// </summary>
        public virtual void SetPauseScreen()
        {
            if (!_pauseScreen.activeInHierarchy)
            {
                GuiManager.Instance.SetScreenActive(_pauseScreen);
                _currentScreen = _pauseScreen;
            }
        }

        /// <summary>
        /// Hide the current screen.
        /// </summary>
        public virtual void HideCurrentScreen()
        {
            GuiManager.Instance.SetScreenInActive(_currentScreen);
            _currentScreen = _gameScreen;
        }

        /// <summary>
        /// Sets the Win screen.
        /// </summary>
        public virtual void SetWinScreen()
        {
            GuiManager.Instance.SetScreenActive(_winLevelScreen);
            _currentScreen = _winLevelScreen;
        }

        /// <summary>
        /// Sets the GameOver screen.
        /// </summary>
        public virtual void SetGameOverScreen()
        {
            GuiManager.Instance.SetScreenActive(_gameOverScreen);
            _currentScreen = _gameOverScreen;
        }
    }
}