using System.Collections;
using ConstantineSpace.Tools;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ConstantineSpace.SimpleUI
{
    // All available game states.
    public enum GameState
    {
        Start,
        Home,
        Game,
        Pause,
        Win,
        GameOver
    }

    public class GameData : ScriptableObject
    {
        public readonly Observer<int> ScoreObserver = new Observer<int>(0);

        public readonly StateMachine<GameState> StateMachine = new StateMachine<GameState>();

        /// <summary>
        ///     Updates score.
        /// </summary>
        /// <param name="score"> An additional score.</param>
        public void UpdateScore(int score)
        {
            ScoreObserver.Value += score;
        }

        /// <summary>
        ///     Returns the current score.
        /// </summary>
        /// <returns>The current score.</returns>
        public int GetScore()
        {
            return ScoreObserver.Value;
        }
    }

    public class GameManager : MonoBehaviour
    {
        [Header("Screens")]
        [SerializeField]
        private HomeScreen _homeScreen;
        [SerializeField]
        private GameScreen _gameScreen;
        [SerializeField]
        private PauseScreen _pauseScreen;
        [SerializeField]
        private WinScreen _winScreen;
        [SerializeField]
        private GameOverScreen _gameOverScreen;

        private GameData _gameData;

        private  void OnEnable()
        {
            _gameData = ScriptableObject.CreateInstance<GameData>();

            _gameData.StateMachine.AddState(GameState.Start, () => Debug.Log("Start State ON"), () => Debug.Log("Start State OFF"));
            _gameData.StateMachine.AddState(GameState.Home, () => _homeScreen.StartScreen(), () => _homeScreen.StopScreen());
            _gameData.StateMachine.AddState(GameState.Game, () => _gameScreen.StartScreen(_gameData), () => _gameScreen.StopScreen(_gameData));
            _gameData.StateMachine.AddState(GameState.Pause, () => SetPause(true), () => SetPause(false));
            _gameData.StateMachine.AddState(GameState.Win, () => _winScreen.StartScreen(), () => _winScreen.StopScreen());
            _gameData.StateMachine.AddState(GameState.GameOver, () =>_gameOverScreen.StartScreen(), () => _gameOverScreen.StopScreen());

            _gameData.StateMachine.SetState(GameState.Start);
        }

        private void Start()
        {
            _homeScreen.StartButton += StartLevel;
            _gameScreen.PauseButton += Pause;
            _gameScreen.WinButton += WinLevel;
            _gameScreen.LoseButton += GameOver;
            _pauseScreen.HomeButton += GoToHome;
            _pauseScreen.RestartButton += Restart;
            _pauseScreen.ContinueButton += UnPause;
            _winScreen.RestartButton += Restart;
            _winScreen.NextLevelButton += GoToNextLevel;
            _gameOverScreen.HomeButton += GoToHome;
            _gameOverScreen.RestartButton += Restart;

            _gameData.StateMachine.SetState(GameState.Home);
        }

        /// <summary>
        ///     Start the level or gameplay.
        /// </summary>
        private void StartLevel()
        {
            Debug.Log("Start game!");
            _gameData.StateMachine.SetState(GameState.Game);
        }

        /// <summary>
        ///     Pause the game.
        /// </summary>
        private void Pause()
        {
            Debug.Log("Pause game!");
            _gameData.StateMachine.SetState(GameState.Pause);
        }

        /// <summary>
        ///     Sets the gameplay pause.
        /// </summary>
        /// <param name="state">The new state.</param>
        private void SetPause(bool state)
        {
            if (state)
            {
                _pauseScreen.StartScreen();
                StartCoroutine(PauseGame(true, _pauseScreen.AnimationDuration));
            }
            else
            {
                _pauseScreen.StopScreen();
                StartCoroutine(PauseGame(false, 0.0f));
            }
        }

        /// <summary>
        ///     Continue the game.
        /// </summary>
        private void UnPause()
        {
            Debug.Log("Continue game!");
            _gameData.StateMachine.SetState(GameState.Game);
        }

        /// <summary>
        ///     Win the level.
        /// </summary>
        private void WinLevel()
        {
            _gameData.StateMachine.SetState(GameState.Win);
        }

        /// <summary>
        ///     Game over.
        /// </summary>
        private void GameOver()
        {
            _gameData.StateMachine.SetState(GameState.GameOver);
        }

        /// <summary>
        ///     Restart the game.
        /// </summary>
        private void Restart()
        {
            Debug.Log("Restart game!");
            _gameData.StateMachine.SetState(GameState.Game);
        }

        /// <summary>
        ///     Go to the Home screen.
        /// </summary>
        private void GoToHome()
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("Main");
        }

        /// <summary>
        ///     Go to the next level.
        /// </summary>
        private void GoToNextLevel()
        {
            Debug.Log("Next level!");
            _gameData.StateMachine.SetState(GameState.Game);
        }

        private  void OnDisable()
        {
            _homeScreen.StartButton -= StartLevel;
            _gameScreen.PauseButton -= Pause;
            _gameScreen.WinButton -= WinLevel;
            _gameScreen.LoseButton -= GameOver;
            _pauseScreen.HomeButton -= GoToHome;
            _pauseScreen.RestartButton -= Restart;
            _pauseScreen.ContinueButton -= UnPause;
            _winScreen.RestartButton -= Restart;
            _winScreen.NextLevelButton -= GoToNextLevel;
            _gameOverScreen.HomeButton -= GoToHome;
            _gameOverScreen.RestartButton -= Restart;
        }

        /// <summary>
        ///     Pauses gameplay after the delay.
        /// </summary>
        /// <param name="state">Turn on/off time pause.</param>
        /// <param name="delay">The delay time.</param>
        /// <returns></returns>
        private IEnumerator PauseGame(bool state, float delay)
        {
            yield return new WaitForSeconds(delay);
            Time.timeScale = state ? 0.0f : 1.0f;
        }
    }
}