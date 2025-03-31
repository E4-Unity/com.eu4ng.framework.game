using UnityEngine;

namespace Eu4ng.System.Item
{
    public abstract class ItemConfig : ScriptableObject
    {

    }

    public abstract class ItemConfig<TData, TItemConfig> : ItemConfig where TData : struct where TItemConfig : ItemConfig<TData, TItemConfig>
    {
        [SerializeField] TData m_Data;

        public TData Data => m_Data;

        public static void GetDataFromItemDefinition(ItemDefinition itemDefinition, out TData data)
        {
            data = default;
            var itemConfig = itemDefinition.GetItemConfig<TItemConfig>();
            if (itemConfig != null) data = itemConfig.Data;
        }
    }
}
