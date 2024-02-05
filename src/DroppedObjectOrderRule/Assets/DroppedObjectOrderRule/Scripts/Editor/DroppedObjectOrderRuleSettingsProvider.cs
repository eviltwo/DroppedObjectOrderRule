using System.Collections.Generic;
using UnityEditor;

namespace DroppedObjectOrderRule
{
    public class DroppedObjectOrderRuleSettingsProvider : SettingsProvider
    {
        private const string SettingPath = "Project/DroppedObjectOrderRule";

        [SettingsProvider]
        public static SettingsProvider CreateProvider()
        {
            return new DroppedObjectOrderRuleSettingsProvider(SettingPath, SettingsScope.Project, null);
        }

        public DroppedObjectOrderRuleSettingsProvider(string path, SettingsScope scopes, IEnumerable<string> keywords) : base(path, scopes, keywords)
        {
        }

        public override void OnGUI(string searchContext)
        {
            EditorGUI.BeginChangeCheck();
            var settings = DroppedObjectOrderRuleSettings.instance;
            settings.Enable = EditorGUILayout.Toggle("Enable", settings.Enable);
            if (EditorGUI.EndChangeCheck())
            {
                settings.Save();
            }
        }
    }
}
