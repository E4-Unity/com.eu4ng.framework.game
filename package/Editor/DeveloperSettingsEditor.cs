using UnityEditor;
using Eu4ng.Manager.Singleton;
using Eu4ng.System.Item;

namespace Eu4ng.Framework.Game.Editor
{
    internal static class DeveloperSettingsEditor
    {
        [MenuItem("Tools/DeveloperSettings/Generate/ItemSystemSettings")]
        static void GenerateItemSystemSettings() => DeveloperSettings.CreateDeveloperSettings(typeof(ItemSystemSettings));
    }
}
