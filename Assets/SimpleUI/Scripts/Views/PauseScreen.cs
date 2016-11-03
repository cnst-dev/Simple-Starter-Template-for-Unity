using System;
using UnityEngine;
using UnityEngine.UI;

namespace ConstantineSpace.SimpleUI
{
    public class PauseScreen : BaseScreen
    {
        [Header("Buttons")]
        [SerializeField]
        private Button _homeButton;
        [SerializeField]
        private Button _restartButton;
        [SerializeField]
        private Button _continueButton;

        // An animation duration.
        public float AnimationDuration = 0.2f;

        public event Action HomeButton;
        public event Action RestartButton;
        public event Action ContinueButton;

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
            _continueButton.onClick.AddListener(() =>
            {
                if (ContinueButton != null) ContinueButton();
            });

            ScreenGoIn(AnimationDuration, 0.0f);
        }

        /// <summary>
        ///     Stops the screen.
        /// </summary>
        /// <param name="gameData"></param>
        public override void StopScreen(GameData gameData = null)
        {
            _homeButton.onClick.RemoveAllListeners();
            _restartButton.onClick.RemoveAllListeners();
            _continueButton.onClick.RemoveAllListeners();
            ScreenGoOut(AnimationDuration, 0.0f);
        }
    }
}