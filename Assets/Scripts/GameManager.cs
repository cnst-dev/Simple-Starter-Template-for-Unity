using ConstantineSpace.Tools;

namespace ConstantineSpace.SimpleUI
{
    public class GameManager : Singleton<GameManager>
    {
        /// <summary>
        /// Initialization.
        /// </summary>
        private void Start()
        {
            ScreenManager.Instance.GoToStart(null);
        }
    }
}