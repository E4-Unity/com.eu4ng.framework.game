using System;
using UnityEngine;

namespace Eu4ng.System.Item
{
    [Serializable]
    public struct ItemData
    {
        public int ID;

        [SerializeField] ItemDefinition itemDefinition;

        public ItemDefinition Definition
        {
            get
            {
                if (itemDefinition == null) itemDefinition = ItemManager.Instance.GetItemDefinition(ID);
                return itemDefinition;
            }

            set => itemDefinition = value;
        }

        [Min(0)]
        public int Quantity;

        public bool IsValid => Definition != null && Quantity > 0;
        public bool IsNotValid => !IsValid;
    }
}
