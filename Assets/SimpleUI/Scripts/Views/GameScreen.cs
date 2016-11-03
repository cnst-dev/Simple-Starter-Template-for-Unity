using System;
using ConstantineSpace.Tools;
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

        [Header("Text")]
        [SerializeField]
        private Text _scoreText;

        public event Action PauseButton;
        public event Action WinButton;
        public event Action LoseButton;

        /// <summary>
        ///     Starts the screen.
        /// </summary>
        /// <param name="gameData"></param>
        public override void StartScreen(GameData gameData)
        {
            gameObject.SetActive(true);

            gameData.ScoreObserver.OnValueChanged += SetScoreText;

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
        /// <param name="gameData"></param>
        public override void StopScreen(GameData gameData)
        {
            gameData.ScoreObserver.OnValueChanged -= SetScoreText;

            _pauseButton.onClick.RemoveAllListeners();
            _winButton.onClick.RemoveAllListeners();
            _loseButton.onClick.RemoveAllListeners();

            gameObject.SetActive(false);
        }

        /// <summary>
        ///     Sets the new score text.
        /// </summary>
        private void SetScoreText(object sender, ChangedValueArgs<int> args)
        {
            _scoreText.text = args.Value.ToString("0000");
        }
    }
}