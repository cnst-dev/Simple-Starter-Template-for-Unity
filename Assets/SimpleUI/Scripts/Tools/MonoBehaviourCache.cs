using UnityEngine;

namespace ConstantineSpace.SimpleUI
{
    /// <summary>
    ///     Use for caching in MonoBehavior.
    /// </summary>
    public abstract class MonoBehaviourCache : MonoBehaviour
    {
        protected Transform _cachedTransform;
        protected GameObject _cachedGameObject;

        public new Transform transform
        {
            get
            {
                if (_cachedTransform == null)
                {
                    _cachedTransform = base.transform;
                }
                return _cachedTransform;
            }
        }

        public new GameObject gameObject
        {
            get
            {
                if (_cachedGameObject == null)
                {
                    _cachedGameObject = base.gameObject;
                }
                return _cachedGameObject;
            }
        }

        private void Awake()
        {
            if (_cachedTransform == null)
            {
                _cachedTransform = base.transform;
            }

            if (_cachedGameObject == null)
            {
                _cachedGameObject = base.gameObject;
            }
        }
    }
}