using System;
using Eu4ng.System.Item;
using UnityEngine;

namespace Eu4ng.System.Inventory.Sample
{
    public interface IInventoryItemConfig : Eu4ng.System.Inventory.IInventoryItemConfig
    {
        public int TestValue { get; }
    }

    [Serializable]
    public struct InventoryItemConfigData : IInventoryItemConfig
    {
        [Min(0)]
        [SerializeField] int m_MaxStack;

        [SerializeField] int m_TestValue;

        public int MaxStack
        {
            get => m_MaxStack;
            set => m_MaxStack = value;
        }

        public int TestValue
        {
            get => m_TestValue;
            set => m_TestValue = value;
        }
    }

#if USE_E4_INVENTORY_SYSTEM
    [CreateAssetMenu(fileName = "ItemConfig_Inventory", menuName = "Scriptable Objects/ItemConfig/InventorySample")]
#endif
    public class ItemConfig_Inventory : ItemConfig<InventoryItemConfigData>
    {

    }
}
