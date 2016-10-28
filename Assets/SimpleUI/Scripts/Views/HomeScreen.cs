using System;
using ConstantineSpace.Tools;
using UnityEngine;
using UnityEngine.UI;

namespace SimpleUI.PinBall
{
    public class HomeScreen: MonoBehaviour
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
        public void StartScreen()
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

            ScreenGoIn(0.3f, 0.0f);
        }

        /// <summary>
        ///     Stops the screen.
        /// </summary>
        public void StopScreen()
        {
            _startButton.onClick.RemoveAllListeners();
            _leaderButton.onClick.RemoveAllListeners();
            _shareButton.onClick.RemoveAllListeners();

            ScreenGoOut(0.3f, 0.0f);
        }

        /// <summary>
        ///     The screen scale animation from 1 to 0.
        /// </summary>
        /// <param name="duration">The duration of the animation.</param>
        /// <param name="delay">The delay before the animation.</param>
        private void ScreenGoIn(float duration, float delay)
        {
            gameObject.SetActive(true);
            gameObject.transform.localScale = Vector3.zero;
            StartCoroutine(SimpleAnimator.ScaleAnimation(gameObject, 1, duration, delay, () =>
            {
                gameObject.transform.localScale = Vector3.one;
            }));
        }

        /// <summary>
        ///     The screen scale animation from 0 to 1.
        /// </summary>
        /// <param name="duration">The duration of the animation.</param>
        /// <param name="delay">The delay before the animation.</param>
        private void ScreenGoOut(float duration, float delay)
        {
            gameObject.transform.localScale = Vector3.one;
            StartCoroutine(SimpleAnimator.ScaleAnimation(gameObject, 0, duration, delay, () =>
            {
                gameObject.transform.localScale = Vector3.zero;
                gameObject.SetActive(false);
            }));
        }

    }
}