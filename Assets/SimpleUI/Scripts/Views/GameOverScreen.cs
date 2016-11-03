using System;
using UnityEngine;
using UnityEngine.UI;

namespace ConstantineSpace.SimpleUI
{
    public class GameOverScreen : BaseScreen
    {
        [Header("Buttons")]
        [SerializeField]
        private Button _homeButton;
        [SerializeField]
        private Button _restartButton;

        public event Action HomeButton;
        public event Action RestartButton;

        /// <summary>
        ///     Starts the screen.
        /// </summary>
        /// <param name="gameData"></param>
        public override void StartScreen(GameData gameData = null)
        {
            _homeButton.onClick.AddListener(() =>
            {
                if (HomeButton != null) HomeButton();
            });
            _restartButton.onClick.AddListener(() =>
            {
                if (RestartButton != null) RestartButton();
            });

            ScreenGoIn(0.2f, 0.0f);
        }

        /// <summary>
        ///     Stops the screen.
        /// </summary>
        /// <param name="gameData"></param>
        public override void StopScreen(GameData gameData = null)
        {
            _homeButton.onClick.RemoveAllListeners();
            _restartButton.onClick.RemoveAllListeners();

            ScreenGoOut(0.2f, 0.0f);
        }
    }
}