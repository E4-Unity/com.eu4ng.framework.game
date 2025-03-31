using UnityEngine;

namespace Eu4ng.Framework.Game
{
    public abstract class ActorComponent : ComponentBase
    {
        Actor m_Owner;

        public Actor Owner
        {
            get => m_Owner;
            set
            {
                if (m_Owner != null) return;
                m_Owner = value;
            }
        }
    }
}
