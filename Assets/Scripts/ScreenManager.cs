using ConstantineSpace.Tools;
using UnityEngine;
#pragma warning disable 649

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
        private GameObject _currentScreen;

        /// <summary>
        /// Sets the Start screen.
        /// </summary>
        public virtual void SetHomeScreen()
        {
            GuiManager.Instance.SetScreenState(_homeScreen, true);
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
            GuiManager.Instance.SetScreenState(_gameScreen, true, 0);
            _currentScreen = _gameScreen;
        }

        /// <summary>
        /// Hides the Game screen.
        /// </summary>
        public virtual void HideGameScreen()
        {
            GuiManager.Instance.SetScreenState(_gameScreen, false);
        }

        /// <summary>
        /// Sets the Pause screen.
        /// </summary>
        public virtual void SetPauseScreen()
        {
            if (GameManager.Instance.CurrentState != GameManager.GameState.InGame) return;
            GuiManager.Instance.SetScreenState(_pauseScreen, true);
            _currentScreen = _pauseScreen;
        }

        /// <summary>
        /// Hide the current screen.
        /// </summary>
        public virtual void HideCurrentScreen()
        {
            GuiManager.Instance.SetScreenState(_currentScreen, false);
            _currentScreen = _gameScreen;
        }

        /// <summary>
        /// Sets the Win screen.
        /// </summary>
        public virtual void SetWinScreen()
        {
            GuiManager.Instance.SetScreenState(_winLevelScreen, true);
            _currentScreen = _winLevelScreen;
        }

        /// <summary>
        /// Sets the GameOver screen.
        /// </summary>
        public virtual void SetGameOverScreen()
        {
            GuiManager.Instance.SetScreenState(_gameOverScreen, true);
            _currentScreen = _gameOverScreen;
        }
    }
}