using ConstantineSpace.SimpleUI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ConstantineSpace.Tools
{
    /// <summary>
    ///     Touch system interface.
    /// </summary>
    public interface ITouchHandler : IEventSystemHandler
    {
        void OnTouched();
    }

    /// <summary>
    ///     Checks touching and creates events.
    /// </summary>
    public class TouchManager : MonoBehaviour
    {
        private void Update()
        {
            if (!Input.GetMouseButtonDown(0)) return;

            var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var hit = Physics2D.Raycast(position, Vector2.zero);
            if (hit.collider == null) return;
            ExecuteEvents.Execute<ITouchHandler>(hit.collider.gameObject, null,
                (handler, data) => handler.OnTouched());
        }
    }
}