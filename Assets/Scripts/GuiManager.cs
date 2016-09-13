using System;
using System.Collections;
using ConstantineSpace.Tools;
using UnityEngine;

namespace ConstantineSpace.SimpleUI
{
    public class GuiManager : Singleton<GuiManager>
    {
        /// <summary>
        /// Sets the screen active.
        /// </summary>
        /// <param name="screen">The screen game object.</param>
        /// <param name="state">The new state of the screen. True - active, false - inactive.</param>
        /// <param name="time">The duration of the animation.</param>
        public virtual void SetScreenState(GameObject screen, bool state, float time = 0.3f)
        {
            if (state)
            {
                ScreenGoIn(screen, time, 0);
            }
            else
            {
                ScreenGoOut(screen, time, 0);
            }
        }

        /// <summary>
        /// The screen scale animation from 1 to 0.
        /// </summary>
        /// <param name="screen">The screen game object for the scaling animation.</param>
        /// <param name="time">The duration of the animation.</param>
        /// <param name="delay">The delay before the animation.</param>
        private void ScreenGoOut(GameObject screen, float time, float delay)
        {
            screen.transform.localScale = Vector3.one;
            StartCoroutine(ScaleAnimation(screen, 0, time, delay, () =>
            {
                screen.transform.localScale = Vector3.zero;
                screen.SetActive(false);
            }));
        }

        /// <summary>
        /// The screen scale animation from 0 to 1.
        /// </summary>
        /// <param name="screen">The screen game object for the scaling animation.</param>
        /// <param name="time">The duration of the animation.</param>
        /// <param name="delay">The delay before the animation.</param>
        private void ScreenGoIn(GameObject screen, float time, float delay)
        {
            screen.transform.localScale = Vector3.zero;
            StartCoroutine(ScaleAnimation(screen, 1, time, delay, () =>
            {
                screen.transform.localScale = Vector3.one;
                screen.SetActive(true);
            }));
        }

        /// <summary>
        /// Do the scale animation.
        /// </summary>
        /// <param name="screen">The screen game object for the scaling animation.</param>
        /// <param name="scale">Scale to.</param>
        /// <param name="time">The duration of the animation.</param>
        /// <param name="delay">The delay before the animation.</param>
        /// <param name="callback">Callback.</param>
        private IEnumerator ScaleAnimation(GameObject screen, float scale, float time, float delay, Action callback)
        {
            screen.SetActive(true);

            yield return new WaitForSeconds(delay);

            var originalScale = screen.transform.localScale;
            var targetScale = Vector3.one * scale;
            var originalTime = time;

            while (time > 0.0f)
            {
                time -= Time.deltaTime;
                screen.transform.localScale = Vector3.Lerp(targetScale, originalScale, time / originalTime);
                yield return 0;
            }

            if (callback != null)
                callback();
        }
    }
}