using Eu4ng.Manager.Singleton;

namespace Eu4ng.System.Item
{
    public class ItemManager : MonoSingleton<ItemManager>
    {
        public ItemDefinition GetItemDefinition(int id) => ItemSystemSettings.Instance.Database.GetItemDefinition(id);

        /* MonoSingleton */

        protected override void OnInitialize() {}
    }
}
