using UnityEngine;

namespace Eu4ng.System.Item
{
    public abstract class ItemConfig : ScriptableObject
    {
        public abstract T GetItemConfigInterface<T>() where T : class, IItemConfig;
    }

    public abstract class ItemConfig<TData> : ItemConfig where TData : struct, IItemConfig
    {
        /* Properties */

        [field: SerializeField]
        public TData Data { get; protected set; }

        /* ItemConfig<TData> */

        public void Initialize(TData data) => Data = data;

        public override T GetItemConfigInterface<T>() => Data as T;
    }
}
