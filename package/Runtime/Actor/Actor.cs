using UnityEngine;

namespace Eu4ng.Framework.Game
{
    public class Actor : ComponentBase
    {
        /* MonoBehaviour */

        protected override void Start()
        {
            InitializeComponent();
        }

        /* ComponentBase */

        protected override void OnInitializeComponent()
        {
            InitializeActorComponents();
        }

        /* Actor */

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
