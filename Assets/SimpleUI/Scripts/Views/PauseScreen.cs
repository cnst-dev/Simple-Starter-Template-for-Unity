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

        public event Action HomeButton;
        public event Action RestartButton;
        public event Action ContinueButton;

        /// <summary>
        ///     Starts the screen.
        /// </summary>
        public override void StartScreen()
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

            ScreenGoIn(0.2f, 0.0f);
        }

        /// <summary>
        ///     Stops the screen.
        /// </summary>
        public override void StopScreen()
        {
            _homeButton.onClick.RemoveAllListeners();
            _restartButton.onClick.RemoveAllListeners();
            _continueButton.onClick.RemoveAllListeners();
            ScreenGoOut(0.2f, 0.0f);
        }
    }
}