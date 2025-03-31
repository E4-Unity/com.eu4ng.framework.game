using System;
using Eu4ng.System.Item;
using UnityEngine;

namespace Eu4ng.System.Inventory
{
    [Serializable]
    public struct InventorySlot
    {
        public int Index;

        public ItemDefinition Definition;

        public int Quantity;

        public static bool operator ==(InventorySlot inventorySlot, int index) => inventorySlot.Index == index;
        public static bool operator !=(InventorySlot inventorySlot, int index) => !(inventorySlot == index);
    }
}
