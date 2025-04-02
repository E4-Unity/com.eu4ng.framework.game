using System.Collections.Generic;
using System.IO;
using Unity.Plastic.Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

namespace Eu4ng.System.Item
{
    public abstract class ItemDataTableRow
    {
        public string DisplayName;
    }

    public abstract class ItemDatabase<T> : ScriptableObject where T : ItemDataTableRow
    {
        [field: SerializeField]
        protected string FolderPath { get; private set; } = "Assets/Resources/ItemDefinitions";

        [field: SerializeField]
        protected TextAsset JsonFile { get; private set; }

        [field: SerializeField]
        protected List<ItemDefinition> ItemDefinitions { get; private set; } = new List<ItemDefinition>();

#if UNITY_EDITOR
        protected virtual void Update()
        {
            var dataTable = JsonConvert.DeserializeObject<Dictionary<int, T>>(JsonFile.text);
            if (dataTable == null) return;
            foreach (var pair in dataTable)
            {
                CreateItemDefinition(pair.Key, pair.Value);
            }
        }

        void CreateItemDefinition(int id, T dataTableRow)
        {
            if (!Directory.Exists(FolderPath)) return;

            var assetPath = FolderPath + "/ItemDefinition_" + id + ".asset";

            var itemDefinition = CreateInstance<ItemDefinition>();
            var itemConfigs = new List<ItemConfig>();
            itemDefinition.Initialize(id, dataTableRow.DisplayName, itemConfigs);
            AssetDatabase.CreateAsset(itemDefinition, assetPath);
            ItemDefinitions.Add(itemDefinition);

            OnItemDefinitionCreated(id, dataTableRow, itemDefinition, itemConfigs);

            foreach (var itemConfig in itemConfigs)
            {
                if (itemConfig == null) continue;
                AssetDatabase.AddObjectToAsset(itemConfig, itemDefinition);
                AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(itemConfig)); // TODO generated inconsistent result for asset
            }
        }

        protected abstract void OnItemDefinitionCreated(int id, T dataTableRow, ItemDefinition itemDefinition, List<ItemConfig> itemConfigs);
#endif
    }
}
