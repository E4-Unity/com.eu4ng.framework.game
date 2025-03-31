using System.Collections.Generic;
using UnityEngine;

namespace Eu4ng.System.Item
{
    [CreateAssetMenu(fileName = "ItemDefinition", menuName = "Scriptable Objects/ItemDefinition")]
    public class ItemDefinition : ScriptableObject
    {
        /* Fields */

        [SerializeField] int m_ID;
        [SerializeField] string m_DisplayName;
        [SerializeField] List<ItemConfig> m_ItemConfigs = new List<ItemConfig>();

        /* Properties */

        public int ID => m_ID;
        public string DisplayName => m_DisplayName;
        protected List<ItemConfig> ItemConfigs => m_ItemConfigs;

        /* ItemDefinition */

        public T GetItemConfig<T>() where T : ItemConfig
        {
            foreach (var itemConfig in ItemConfigs)
            {
                if (itemConfig == null) continue;

                if(itemConfig.GetType() == typeof(T) || itemConfig.GetType().IsSubclassOf(typeof(T))) return (T)itemConfig;
            }

            return null;
        }
    }
}
