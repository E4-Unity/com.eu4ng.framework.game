using UnityEngine;

namespace Eu4ng.Framework.Game
{
    public class Actor : ComponentBase
    {
        /* MonoBehaviour */

        protected override void Awake()
        {
            base.Awake();

            AssignReferences();
            BindEvents();
        }

        protected override void Start()
        {
            InitializeComponent();
        }

        protected override void OnDestroy()
        {
            UnBindEvents();
            
            base.OnDestroy();
        }

        /* ComponentBase */

        protected override void OnInitializeComponent()
        {
            InitializeActorComponents();
        }

        /* Actor */

        protected virtual void AssignReferences() {}
        protected virtual void BindEvents() {}
        protected virtual void UnBindEvents() {}

        protected virtual void InitializeActorComponents()
        {
            var actorComponents = GetComponents<ActorComponent>();
            foreach (var actorComponent in actorComponents)
            {
                actorComponent.Owner = this;
                actorComponent.InitializeComponent();
            }
        }
    }
}
