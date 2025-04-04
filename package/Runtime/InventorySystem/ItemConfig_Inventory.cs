using System;
using Eu4ng.System.Item;
using UnityEngine;

namespace Eu4ng.System.Inventory
{
    public interface IInventoryItem
    {
        public int MaxStack { get; }
    }

    [Serializable]
    public struct InventoryItemData : IInventoryItem
    {
        [field: SerializeField, Min(0)] public int MaxStack { get; set; }
    }

#if USE_E4_INVENTORY_SYSTEM
    [CreateAssetMenu(fileName = "ItemConfig_Inventory", menuName = "Scriptable Objects/ItemConfig/Inventory")]
#endif
    public class ItemConfig_Inventory : ItemConfig<InventoryItemData>
    {

    }
}
