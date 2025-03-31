using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Eu4ng.System.Item
{
    public abstract class ItemConfig : ScriptableObject
    {
        public abstract T GetItemConfigInterface<T>() where T : class, IItemConfig;
    }

    public abstract class ItemConfig<TData> : ItemConfig where TData : struct, IItemConfig
    {
        [SerializeField] TData m_Data;

        public TData Data => m_Data;

        public override T GetItemConfigInterface<T>() => m_Data as T;
    }
}
