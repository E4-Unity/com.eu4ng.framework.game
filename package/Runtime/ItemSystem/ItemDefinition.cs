using System.Collections.Generic;
using UnityEngine;

namespace Eu4ng.System.Item
{
    [CreateAssetMenu(fileName = "ItemDefinition", menuName = "Scriptable Objects/ItemDefinition")]
    public class ItemDefinition : ScriptableObject
    {
        /* Properties */

        [field: SerializeField]
        public int ID { get; protected set; }

        [field: SerializeField]
        public string DisplayName { get; protected set; }

        [field: SerializeField]
        protected List<ItemConfig> ItemConfigs { get; set; }

        /* ItemDefinition */

        public void Initialize(int id, string displayName, List<ItemConfig> itemConfigs)
        {
            ID = id;
            DisplayName = displayName;
            ItemConfigs = itemConfigs;
        }

        public T GetItemConfigInterface<T>() where T : class, IItemConfig
        {
            foreach (var itemConfig in ItemConfigs)
            {
                if (itemConfig == null) continue;

                var itemConfigInterface = itemConfig.GetItemConfigInterface<T>();
                if (itemConfigInterface != null) return itemConfigInterface;
            }

            return null;
        }
    }
}
