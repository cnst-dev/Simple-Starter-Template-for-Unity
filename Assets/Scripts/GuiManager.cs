using ConstantineSpace.Tools;
using UnityEngine;

namespace ConstantineSpace.SimpleUI
{
    public class GuiManager : Singleton<GuiManager>
    {
        [Header("Screens")]
        [SerializeField] private GameObject StartScreen;
        [SerializeField] private GameObject GameScreen;
        [SerializeField] private GameObject PauseScreen;
        [SerializeField] private GameObject EndScreen;

        public virtual void SetStartScreen(bool newState)
        {
            StartScreen.SetActive(newState);
        }

        public virtual void SetPauseScreen(bool newState)
        {
            PauseScreen.SetActive(newState);
        }

        public virtual void SetGameScreen(bool newState)
        {
            GameScreen.SetActive(newState);
        }

        public virtual void SetEndScreen(bool newState)
        {
            EndScreen.SetActive(newState);
        }
    }
}
