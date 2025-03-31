using System;
using Eu4ng.System.Item;
using UnityEngine;

namespace Eu4ng.System.Inventory
{
    [Serializable]
    public struct InventoryItemConfigData : IInventoryItemConfig
    {
        [Min(0)]
        [SerializeField] int m_MaxStack;

        public int MaxStack
        {
            get => m_MaxStack;
            set => m_MaxStack = value;
        }
    }

    public interface IInventoryItemConfig : IItemConfig
    {
        public int MaxStack { get; }
    }

#if USE_E4_INVENTORY_SYSTEM
    [CreateAssetMenu(fileName = "ItemConfig_Inventory", menuName = "Scriptable Objects/ItemConfig/Inventory")]
#endif
    public class ItemConfig_Inventory : ItemConfig<InventoryItemConfigData>
    {

    }
}
