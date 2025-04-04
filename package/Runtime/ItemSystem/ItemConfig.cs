using UnityEngine;

namespace Eu4ng.System.Item
{
    public abstract class ItemConfig : ScriptableObject
    {
        public abstract T GetItemInterface<T>() where T : class;
    }

    public abstract class ItemConfig<TData> : ItemConfig where TData : struct
    {
        /* Properties */

        [field: SerializeField]
        public TData Data { get; protected set; }

        /* ItemConfig<TData> */

        public void Initialize(TData data) => Data = data;
        public override T GetItemInterface<T>() => Data as T;
    }
}
