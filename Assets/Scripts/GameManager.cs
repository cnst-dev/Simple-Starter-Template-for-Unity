using ConstantineSpace.Tools;
using UnityEngine;

namespace ConstantineSpace.SimpleUI
{
    public class GameManager : Singleton<GameManager>
    {
        [Header("Screens")]
        public GameObject StartScreen;
        public GameObject GameScreen;
        public GameObject PauseScreen;
        public GameObject GameOverScreen;
        public GameObject WinLevelScreen;


        /// <summary>
        /// Initialization.
        /// </summary>
        public void Start()
        {
            GuiManager.Instance.SetScreenActive(StartScreen);
        }

        /// <summary>
		/// Sets the Game screen.
		/// </summary>
		/// <param name="currentScreen"> The current screen game object that will be inactive.</param>
        public virtual void GoToGame(GameObject currentScreen)
        {
            GuiManager.Instance.SetScreenActive(currentScreen, GameScreen);
        }

        /// <summary>
        /// Sets the Start screen.
        /// </summary>
        /// <param name="currentScreen"> The current screen game object that will be inactive.</param>
        public virtual void GoToStart(GameObject currentScreen)
        {
            GuiManager.Instance.SetScreenActive(currentScreen, StartScreen);
            GuiManager.Instance.SetScreenInActive(GameScreen);
        }

        /// <summary>
        /// Pauses the game.
        /// </summary>
        public virtual void Pause()
        {
            if (!PauseScreen.activeInHierarchy)
            {
                GuiManager.Instance.SetScreenActive(PauseScreen);
            }
        }

        /// <summary>
        /// Unpauses the game.
        /// </summary>
        public virtual void UnPause()
        {
            Debug.Log("UnPause");
            GuiManager.Instance.SetScreenInActive(PauseScreen);
        }

        /// <summary>
        /// Restarts the game.
        /// </summary>
        public virtual void Restart()
        {
            Debug.Log("Restart");
            GuiManager.Instance.SetScreenInActive(PauseScreen);
        }

        /// <summary>
        /// Sets the Win screen.
        /// </summary>
        public virtual void WinGame()
        {
            GuiManager.Instance.SetScreenActive(WinLevelScreen);
        }
    }
}