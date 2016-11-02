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
        public override void StartScreen()
        {
            gameObject.SetActive(true);

            GameManager.Instance.ScoreObserver.OnDataChanged += () => SetScoreText(GameManager.Instance.ScoreObserver.Value);

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
            GameManager.Instance.ScoreObserver.OnDataChanged += () => SetScoreText(GameManager.Instance.ScoreObserver.Value);

            _pauseButton.onClick.RemoveAllListeners();
            _winButton.onClick.RemoveAllListeners();
            _loseButton.onClick.RemoveAllListeners();

            gameObject.SetActive(false);
        }

        /// <summary>
        ///     Sets the new score text.
        /// </summary>
        /// <param name="score">The new score.</param>
        private void SetScoreText(int score)
        {
            _scoreText.text = score.ToString("0000");
        }
    }
}