using ConstantineSpace.Tools;
using UnityEngine;

namespace ConstantineSpace.SimpleUI
{
    public class GameManager : Singleton<GameManager>
    {
        // Use this for initialization
        protected void Start()
        {
            GuiManager.Instance.SetStartScreen(true);
        }

        /// <summary>
		/// Sets the game screen.
		/// </summary>
        public void GoToGame()
        {
            GuiManager.Instance.SetStartScreen(false);
            GuiManager.Instance.SetGameScreen(true);
        }

        /// <summary>
		/// Sets the game screen.
		/// </summary>
        public void GoTo()
        {
            GuiManager.Instance.SetStartScreen(false);
            GuiManager.Instance.SetGameScreen(true);
        }
    }
}