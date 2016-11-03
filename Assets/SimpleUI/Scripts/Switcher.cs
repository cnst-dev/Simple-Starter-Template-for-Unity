using ConstantineSpace.Tools;
using UnityEngine;

namespace ConstantineSpace.SimpleUI
{
    public class Switcher : MonoBehaviour, ITouchHandler
    {
        [SerializeField]
        private int _score;

        private GameData _gameData;

        private void Start()
        {
            _gameData = FindObjectOfType<GameData>();
        }

        /// <summary>
        ///     Receives touch event.
        /// </summary>
        public void OnTouched()
        {
            _gameData.UpdateScore(_score);
        }
    }
}