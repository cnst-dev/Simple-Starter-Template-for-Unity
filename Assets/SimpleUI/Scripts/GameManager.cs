using ConstantineSpace.Tools;
using SimpleUI.PinBall;
using UnityEngine;

namespace ConstantineSpace.SimpleUI
{
    public class GameManager : Singleton<GameManager>
    {
        // All available game states.
        public enum GameState
        {
            Start,
            Home,
            Game,
            Pause
        }

        [Header("Screens")]
        [SerializeField]
        private HomeScreen _homeScreen;

        public StateMachine<GameState> StateMachine;

        public override void OnCreated()
        {
            StateMachine = new StateMachine<GameState>();
            StateMachine.AddState(GameState.Start, () => Debug.Log("Start State ON"), () => Debug.Log("Start State OFF"));
            StateMachine.AddState(GameState.Home, _homeScreen.StartScreen, _homeScreen.StopScreen);
            StateMachine.AddState(GameState.Game, () => Debug.Log("Game State ON"), () => Debug.Log("Game State OFF"));
            StateMachine.AddState(GameState.Pause, () => Debug.Log("Pause State ON"), () => Debug.Log("Pause State OFF"));

            StateMachine.SetState(GameState.Start);
        }

        private void Start()
        {
            _homeScreen.StartButton += StartLevel;
            StateMachine.SetState(GameState.Home);
        }

        /// <summary>
        ///     Start the level or gameplay.
        /// </summary>
        private void StartLevel()
        {
            StateMachine.SetState(GameState.Game);
        }

        /// <summary>
        ///     Pause the game.
        /// </summary>
        public void Pause()
        {
        }

        /// <summary>
        ///     Continue the game.
        /// </summary>
        public void UnPause()
        {
        }

        /// <summary>
        ///     Win the level.
        /// </summary>
        public void WinLevel()
        {
        }

        /// <summary>
        ///     Game over.
        /// </summary>
        public void GameOver()
        {
        }

        /// <summary>
        ///     Restart the game.
        /// </summary>
        public void Restart()
        {
            Debug.Log("Restart game!");
        }

        /// <summary>
        ///     Go to the Home screen.
        /// </summary>
        public void GoToHome()
        {
        }

        /// <summary>
        ///     Go to the next level.
        /// </summary>
        public void GoToNextLevel()
        {
        }
    }
}