using System.Collections.Generic;
using UnityEngine;

namespace Eu4ng.System.Item
{
    [CreateAssetMenu(fileName = "ItemDefinition", menuName = "Scriptable Objects/ItemDefinition")]
    public class ItemDefinition : ScriptableObject
    {
        /* Properties */

        [field: SerializeField] public int ID { get; private set; }
        [field: SerializeField] public string DisplayName { get; private set; }
        [field: SerializeField] public List<ItemConfig> ItemConfigs { get; private set; } = new List<ItemConfig>();

        /* ItemDefinition */

        public void Initialize(int id, string displayName, List<ItemConfig> itemConfigs)
        {
            ID = id;
            DisplayName = displayName;
            ItemConfigs = itemConfigs;
        }

        public T GetItemInterface<T>() where T : class
        {
            foreach (var itemConfig in ItemConfigs)
            {
                if (itemConfig == null) continue;

                var itemInterface = itemConfig.GetItemInterface<T>();
                if (itemInterface is not null) return itemInterface;
            }

            return null;
        }
    }
}
