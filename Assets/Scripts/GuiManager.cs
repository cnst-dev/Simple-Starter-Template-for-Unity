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
    }
}
