using Eu4ng.Manager.Singleton;
using UnityEngine;

namespace Eu4ng.System.Item
{
    public class ItemSystemSettings : DeveloperSettings<ItemSystemSettings>
    {
        [field: SerializeField]
        public ItemDatabase Database { get; private set; }

        /* DeveloperSettings */

        protected override void OnInitialize() { Database.RefreshItemDefinitionMap(); }
    }
}
