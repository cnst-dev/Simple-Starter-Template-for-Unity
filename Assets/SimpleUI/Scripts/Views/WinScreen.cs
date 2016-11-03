using System;
using UnityEngine;
using UnityEngine.UI;

namespace ConstantineSpace.SimpleUI
{
    public class WinScreen : BaseScreen
    {
        [Header("Buttons")]
        [SerializeField]
        private Button _restartButton;
        [SerializeField]
        private Button _shareButton;
        [SerializeField]
        private Button _nextLevelButton;

        public event Action RestartButton;
        public event Action ShareButton;
        public event Action NextLevelButton;

        /// <summary>
        ///     Starts the screen.
        /// </summary>
        /// <param name="gameData"></param>
        public override void StartScreen(GameData gameData = null)
        {
            _restartButton.onClick.AddListener(() =>
            {
                if (RestartButton != null) RestartButton();
            });
            _shareButton.onClick.AddListener(() =>
            {
                if (ShareButton != null) ShareButton();
            });
            _nextLevelButton.onClick.AddListener(() =>
            {
                if (NextLevelButton != null) NextLevelButton();
            });

            ScreenGoIn(0.2f, 0.0f);
        }

        /// <summary>
        ///     Stops the screen.
        /// </summary>
        /// <param name="gameData"></param>
        public override void StopScreen(GameData gameData = null)
        {
            _restartButton.onClick.RemoveAllListeners();
            _shareButton.onClick.RemoveAllListeners();
            _nextLevelButton.onClick.RemoveAllListeners();

            ScreenGoOut(0.2f, 0.0f);
        }
    }
}