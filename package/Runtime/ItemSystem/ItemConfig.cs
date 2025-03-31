using UnityEngine;

namespace Eu4ng.System.Item
{
    public abstract class ItemConfig : ScriptableObject
    {

    }

    public abstract class ItemConfig<T> : ItemConfig where T : struct
    {
        [SerializeField] T m_Data;

        public T Data => m_Data;
    }
}
