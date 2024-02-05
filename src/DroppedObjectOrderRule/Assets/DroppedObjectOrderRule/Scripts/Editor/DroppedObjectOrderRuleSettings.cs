using UnityEditor;

namespace DroppedObjectOrderRule
{
    [FilePath("ProjectSettings/DroppedObjectOrderRuleSettings.asset", FilePathAttribute.Location.ProjectFolder)]
    public class DroppedObjectOrderRuleSettings : ScriptableSingleton<DroppedObjectOrderRuleSettings>
    {
        public bool Enable = true;

        public void Save()
        {
            Save(true);
        }
    }
}

