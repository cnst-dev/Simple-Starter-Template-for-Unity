using System;
using UnityEngine;
using UnityEngine.UI;

namespace ConstantineSpace.SimpleUI
{
    public class HomeScreen: BaseScreen
    {
        [Header("Buttons")]
        [SerializeField]
        private Button _startButton;
        [SerializeField]
        private Button _leaderButton;
        [SerializeField]
        private Button _shareButton;

        public event Action StartButton;
        public event Action LeaderButton;
        public event Action ShareButton;

        /// <summary>
        ///     Starts the screen.
        /// </summary>
        /// <param name="gameData"></param>
        public override void StartScreen(GameData gameData = null)
        {
            _startButton.onClick.AddListener(() =>
            {
                if (StartButton != null) StartButton();
            });

            _leaderButton.onClick.AddListener(() =>
            {
                if (LeaderButton != null) LeaderButton();
            });

            _shareButton.onClick.AddListener(() =>
            {
                if (ShareButton != null) ShareButton();
            });

            ScreenGoIn(0.2f, 0.0f);
        }

        /// <summary>
        ///     Stops the screen.
        /// </summary>
        /// <param name="gameData"></param>
        public override void StopScreen(GameData gameData = null)
        {
            _startButton.onClick.RemoveAllListeners();
            _leaderButton.onClick.RemoveAllListeners();
            _shareButton.onClick.RemoveAllListeners();

            ScreenGoOut(0.2f, 0.0f);
        }

    }
}