using System;
using Eu4ng.System.Item;
using UnityEngine;

namespace Eu4ng.System.Inventory.Sample
{
    public interface IInventoryItem : Eu4ng.System.Inventory.IInventoryItem
    {
        public int TestValue { get; }
    }

    [Serializable]
    public struct InventoryItemData : IInventoryItem
    {
        [field: SerializeField, Min(0)] public int MaxStack { get; set; }

        [field: SerializeField] public int TestValue { get; set; }
    }

#if USE_E4_INVENTORY_SYSTEM
    [CreateAssetMenu(fileName = "ItemConfig_Inventory", menuName = "Scriptable Objects/ItemConfig/InventorySample")]
#endif
    public class ItemConfig_Inventory : ItemConfig<InventoryItemData>
    {

    }
}
