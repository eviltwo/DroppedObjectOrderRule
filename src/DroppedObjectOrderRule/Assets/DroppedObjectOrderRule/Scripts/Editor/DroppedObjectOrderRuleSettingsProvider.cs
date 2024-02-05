using System.Collections.Generic;
using UnityEditor;

namespace DroppedObjectOrderRule
{
    public class DroppedObjectOrderRuleSettingsProvider : SettingsProvider
    {
        private const string SettingPath = "Project/DroppedObjectOrderRule";
        private static readonly string[] Keywords = { "Order", "Sibling" };

        [SettingsProvider]
        public static SettingsProvider CreateProvider()
        {
            return new DroppedObjectOrderRuleSettingsProvider(SettingPath, SettingsScope.Project, Keywords);
        }

        public DroppedObjectOrderRuleSettingsProvider(string path, SettingsScope scopes, IEnumerable<string> keywords) : base(path, scopes, keywords)
        {
        }

        public override void OnGUI(string searchContext)
        {
            using (var check = new EditorGUI.ChangeCheckScope())
            {
                var settings = DroppedObjectOrderRuleSettings.instance;
                settings.Enable = EditorGUILayout.Toggle("Enable", settings.Enable);

                if (check.changed)
                {
                    settings.Save();
                }
            }
        }
    }
}
