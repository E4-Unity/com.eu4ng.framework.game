using UnityEngine;

namespace Eu4ng.Framework.Game
{
    public abstract class ComponentBase : MonoBehaviour
    {
        public bool IsInitialized { get; private set; }

        public void InitializeComponent()
        {
            if (IsInitialized) return;
            IsInitialized = true;

            OnInitializeComponent();
        }

        protected virtual void OnInitializeComponent() {}

        /* MonoBehaviour */

        protected virtual void Awake() {}
        protected virtual void OnEnable() {}
        protected virtual void Start() {}
        protected virtual void FixedUpdate() {}
        protected virtual void Update() {}
        protected virtual void LateUpdate() {}
        protected virtual void OnDisable() {}
        protected virtual void OnDestroy() {}
    }
}
