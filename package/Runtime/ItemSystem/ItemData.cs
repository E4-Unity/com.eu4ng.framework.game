using System;
using UnityEngine;

namespace Eu4ng.System.Item
{
    [Serializable]
    public struct ItemData
    {
        public ItemDefinition Definition;

        [Min(0)]
        public int Quantity;

        public bool IsValid => Definition != null && Quantity > 0;
        public bool IsNotValid => !IsValid;
    }
}
