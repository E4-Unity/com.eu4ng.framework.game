using System.Collections.Generic;
using Eu4ng.Utilities.Editor;
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

        protected Dictionary<int, ItemDefinition> ItemDefinitionMap { get; private set; } = new Dictionary<int, ItemDefinition>();

        public ItemDefinition GetItemDefinition(int id) => ItemDefinitionMap.GetValueOrDefault(id, null);

        protected void RefreshItemDefinitionMap()
        {
            ItemDefinitionMap.Clear();

            foreach (var itemDefinition in ItemDefinitions)
            {
                if (itemDefinition == null) continue;
                ItemDefinitionMap.Add(itemDefinition.ID, itemDefinition);
            }
        }

#if UNITY_EDITOR
        protected virtual void HardUpdate()
        {
            Clear();

            Update();
        }

        protected virtual void SoftUpdate()
        {
            RefreshItemDefinitionMap();

            Update();
        }

        protected virtual void Update()
        {
            var dataTable = JsonConvert.DeserializeObject<Dictionary<int, T>>(JsonFile.text);
            if (dataTable == null) return;
            foreach (var pair in dataTable)
            {
                CreateItemDefinition(pair.Key, pair.Value);
            }
        }

        protected virtual void Clear()
        {
            foreach (var itemDefinition in ItemDefinitions)
            {
                AssetDatabase.DeleteAsset(AssetDatabase.GetAssetPath(itemDefinition));
            }

            ItemDefinitions.Clear();
            ItemDefinitionMap.Clear();
        }

        public ItemDefinition GetOrCreateItemDefinition(int id)
        {
            var itemDefinition = GetItemDefinition(id);
            if (itemDefinition == null)
            {
                itemDefinition = CreateInstance<ItemDefinition>();
                DirectoryManager.CreateAsset(itemDefinition, FolderPath, "ItemDefinition_" + id);
                ItemDefinitions.Add(itemDefinition);
            }

            return itemDefinition;
        }

        void CreateItemDefinition(int id, T dataTableRow)
        {
            if (id < 0 || dataTableRow == null) return;

            var itemDefinition = GetOrCreateItemDefinition(id);
            var itemConfigs = new List<ItemConfig>();
            itemDefinition.Initialize(id, dataTableRow.DisplayName, itemConfigs);

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
