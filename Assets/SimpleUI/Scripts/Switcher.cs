using ConstantineSpace.Tools;
using UnityEngine;

namespace ConstantineSpace.SimpleUI
{
    public class Switcher : MonoBehaviour, ITouchHandler
    {
        [SerializeField]
        private int _score;

        /// <summary>
        ///     Receives touch event.
        /// </summary>
        public void OnTouched()
        {
            GameManager.Instance.UpdateScore(_score);
        }
    }
}