using System;
using Eu4ng.System.Item;
using UnityEngine;

namespace Eu4ng.System.Inventory
{
    [Serializable]
    public struct InventoryItemConfigData
    {
        [Min(0)]
        public int MaxStack;
    }

#if USE_E4_INVENTORY_SYSTEM
    [CreateAssetMenu(fileName = "ItemConfig_Inventory", menuName = "Scriptable Objects/ItemConfig/Inventory")]
#endif
    public class ItemConfig_Inventory : ItemConfig<InventoryItemConfigData, ItemConfig_Inventory>
    {

    }
}
