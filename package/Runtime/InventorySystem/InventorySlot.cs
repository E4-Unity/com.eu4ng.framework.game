using System;
using Eu4ng.System.Item;
using UnityEngine;

namespace Eu4ng.System.Inventory
{
    [Serializable]
    public struct InventorySlot : IEquatable<InventorySlot>
    {
        public int Index;

        public ItemDefinition Definition;

        public int Quantity;

        public static bool operator ==(InventorySlot inventorySlot, int index) => inventorySlot.Index == index;
        public static bool operator !=(InventorySlot inventorySlot, int index) => !(inventorySlot == index);

        public bool Equals(InventorySlot other)
        {
            return Index == other.Index && Equals(Definition, other.Definition) && Quantity == other.Quantity;
        }

        public override bool Equals(object obj)
        {
            return obj is InventorySlot other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Index, Definition, Quantity);
        }
    }
}
