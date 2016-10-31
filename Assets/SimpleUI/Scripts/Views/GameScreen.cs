using System;
using UnityEngine;
using UnityEngine.UI;

namespace ConstantineSpace.SimpleUI
{
    public class GameScreen : BaseScreen
    {
        [Header("Buttons")]
        [SerializeField]
        private Button _pauseButton;
        [SerializeField]
        private Button _winButton;
        [SerializeField]
        private Button _loseButton;

        public event Action PauseButton;
        public event Action WinButton;
        public event Action LoseButton;

        /// <summary>
        ///     Starts the screen.
        /// </summary>
        public override void StartScreen()
        {
            gameObject.SetActive(true);
            
            _pauseButton.onClick.AddListener(() =>
            {
                if (PauseButton != null) PauseButton();
            });
            _winButton.onClick.AddListener(() =>
            {
                if (WinButton != null) WinButton();
            });
            _loseButton.onClick.AddListener(() =>
            {
                if (LoseButton != null) LoseButton();
            });
        }

        /// <summary>
        ///     Stops the screen.
        /// </summary>
        public override void StopScreen()
        {
            _pauseButton.onClick.RemoveAllListeners();
            _winButton.onClick.RemoveAllListeners();
            _loseButton.onClick.RemoveAllListeners();
            gameObject.SetActive(false);
        }
    }
}