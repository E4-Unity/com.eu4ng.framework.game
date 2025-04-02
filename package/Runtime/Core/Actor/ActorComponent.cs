using Eu4ng.Utilities;
using UnityEngine;

namespace Eu4ng.Framework.Game
{
    public class ActorComponent : ComponentBase
    {
        [SerializeField, ReadOnly] Actor m_Owner;

        public Actor Owner
        {
            get => m_Owner;
            set
            {
                if (m_Owner != null) return;
                m_Owner = value;
            }
        }

        /* MonoBehaviour */

        protected override void OnInitializeComponent()
        {
            base.OnInitializeComponent();

            AssignReferences();
            BindEvents();
        }

        protected override void OnDestroy()
        {
            UnBindEvents();

            base.OnDestroy();
        }
    }
}
