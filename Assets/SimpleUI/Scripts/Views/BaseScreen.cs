using ConstantineSpace.Tools;
using UnityEngine;

namespace ConstantineSpace.SimpleUI
{
    public abstract class BaseScreen : MonoBehaviour
    {
        /// <summary>
        ///     Starts the screen.
        /// </summary>
        public abstract void StartScreen();

        /// <summary>
        ///     Stops the screen.
        /// </summary>
        public abstract void StopScreen();

        /// <summary>
        ///     The screen scale animation from 1 to 0.
        /// </summary>
        /// <param name="duration">The duration of the animation.</param>
        /// <param name="delay">The delay before the animation.</param>
        protected void ScreenGoIn(float duration, float delay)
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
        protected void ScreenGoOut(float duration, float delay)
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