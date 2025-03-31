using System.Collections.Generic;
using Eu4ng.Framework.Game;
using Eu4ng.System.Item;
using Eu4ng.Utilities;
using UnityEngine;

namespace Eu4ng.System.Inventory
{
    public class InventoryComponent : ActorComponent
    {
        [SerializeField, Min(0)] int m_MaxSlotNum = 4;
        [SerializeField] List<ItemData> m_StartItems = new List<ItemData>();
        [SerializeField, ReadOnly] List<InventorySlot> m_InventorySlots = new List<InventorySlot>();

        protected int MaxSlotNum => m_MaxSlotNum;
        protected List<ItemData> StartItems => m_StartItems;
        protected Dictionary<int, InventorySlot> InventorySlotMap { get; } = new Dictionary<int, InventorySlot>();

        protected List<InventorySlot> InventorySlots => m_InventorySlots;

        /* MonoBehaviour */

        protected override void Start()
        {
            base.Start();

            foreach (var item in StartItems)
            {
                AddItem(item);
            }
        }

        public virtual void AddItem(ItemData item)
        {
            if (item.IsNotValid) return;

            ItemConfig_Inventory.GetDataFromItemDefinition(item.Definition, out var data);
            int maxStack = data.MaxStack;

            for (int index = 0; index < MaxSlotNum; ++index)
            {
                if(InventorySlotMap.ContainsKey(index)) continue;

                int QuantityToAdd = maxStack >= item.Quantity ? item.Quantity : maxStack;
                item.Quantity -= QuantityToAdd;

                InventorySlot newInventorySlot = new InventorySlot
                {
                    Index = index,
                    Definition = item.Definition,
                    Quantity = QuantityToAdd
                };

                InventorySlots.Add(newInventorySlot);
                InventorySlotMap.Add(index, newInventorySlot);

                if (item.Quantity <= 0) break;
            }
        }
    }
}
