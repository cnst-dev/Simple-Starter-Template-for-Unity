using ConstantineSpace.Tools;
using UnityEngine;

namespace ConstantineSpace.SimpleUI
{
    public abstract class BaseScreen : MonoBehaviourCache
    {
        /// <summary>
        ///     Starts the screen.
        /// </summary>
        /// <param name="gameData"></param>
        public abstract void StartScreen(GameData gameData = null);

        /// <summary>
        ///     Stops the screen.
        /// </summary>
        /// <param name="gameData"></param>
        public abstract void StopScreen(GameData gameData = null);

        /// <summary>
        ///     The screen scale animation from 1 to 0.
        /// </summary>
        /// <param name="duration">The duration of the animation.</param>
        /// <param name="delay">The delay before the animation.</param>
        protected void ScreenGoIn(float duration, float delay)
        {
            gameObject.SetActive(true);
            transform.localScale = Vector3.zero;
            StartCoroutine(SimpleAnimator.ScaleAnimation(gameObject, 1, duration, delay, () =>
            {
                transform.localScale = Vector3.one;
            }));
        }

        /// <summary>
        ///     The screen scale animation from 0 to 1.
        /// </summary>
        /// <param name="duration">The duration of the animation.</param>
        /// <param name="delay">The delay before the animation.</param>
        protected void ScreenGoOut(float duration, float delay)
        {
            transform.localScale = Vector3.one;
            StartCoroutine(SimpleAnimator.ScaleAnimation(gameObject, 0, duration, delay, () =>
            {
                transform.localScale = Vector3.zero;
                gameObject.SetActive(false);
            }));
        }

    }
}