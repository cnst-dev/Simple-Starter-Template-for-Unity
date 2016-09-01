using ConstantineSpace.Tools;
using UnityEngine;

namespace ConstantineSpace.SimpleUI
{
    public class GuiManager : Singleton<GuiManager>
    {
        [Header("Screens")]
        [SerializeField] private GameObject _startScreen;
        [SerializeField] private GameObject _gameScreen;
        [SerializeField] private GameObject _pauseScreen;
        [SerializeField] private GameObject _endScreen;

        public virtual void SetStartScreen(bool newState)
        {
            _startScreen.SetActive(newState);
        }

        public virtual void SetPauseScreen(bool newState)
        {
            _pauseScreen.SetActive(newState);
        }

        public virtual void SetGameScreen(bool newState)
        {
            _gameScreen.SetActive(newState);
        }

        public virtual void SetEndScreen(bool newState)
        {
            _endScreen.SetActive(newState);
        }
    }
}
