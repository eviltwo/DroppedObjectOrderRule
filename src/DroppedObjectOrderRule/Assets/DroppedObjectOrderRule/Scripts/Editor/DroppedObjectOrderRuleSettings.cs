using System.Collections.Generic;
using UnityEditor;

namespace DroppedObjectOrderRule
{
    [FilePath("ProjectSettings/DroppedObjectOrderRuleSettings.asset", FilePathAttribute.Location.ProjectFolder)]
    public class DroppedObjectOrderRuleSettings : ScriptableSingleton<DroppedObjectOrderRuleSettings>
    {
        public bool Enable = true;
        public List<OrderRuleOperationArgument> Operations = new List<OrderRuleOperationArgument>
        {
            new OrderRuleOperationArgument { Operation = OrderRuleOperation.MoveToLast },
        };

        public void Save()
        {
            Save(true);
        }
    }
}

