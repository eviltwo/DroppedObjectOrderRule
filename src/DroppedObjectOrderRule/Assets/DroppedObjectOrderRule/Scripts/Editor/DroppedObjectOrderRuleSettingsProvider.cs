using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;

namespace DroppedObjectOrderRule
{
    public class DroppedObjectOrderRuleSettingsProvider : SettingsProvider
    {
        private const string SettingPath = "Project/DroppedObjectOrderRule";
        private static readonly string[] Keywords = { "Order", "Sibling" };
        private ReorderableList _reorderableList;

        [SettingsProvider]
        public static SettingsProvider CreateProvider()
        {
            return new DroppedObjectOrderRuleSettingsProvider(SettingPath, SettingsScope.Project, Keywords);
        }

        public DroppedObjectOrderRuleSettingsProvider(string path, SettingsScope scopes, IEnumerable<string> keywords) : base(path, scopes, keywords)
        {
        }

        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            DroppedObjectOrderRuleSettings.instance.hideFlags = HideFlags.HideAndDontSave & ~HideFlags.NotEditable;
            _reorderableList = new ReorderableList(DroppedObjectOrderRuleSettings.instance.Operations, typeof(OrderRuleOperationArgument), true, true, true, true);
            _reorderableList.drawHeaderCallback = rect => EditorGUI.LabelField(rect, "Operations");
            _reorderableList.drawElementCallback = OnDrawRulesElement;
        }

        private void OnDrawRulesElement(Rect rect, int index, bool active, bool forcused)
        {
            var rules = DroppedObjectOrderRuleSettings.instance.Operations;
            var rule = rules[index];
            var operationRect = new Rect(rect.x, rect.y, rect.width / 2, rect.height);
            rule.Operation = (OrderRuleOperation)EditorGUI.EnumPopup(operationRect, rule.Operation);
            if (OrderRuleOperationOptionDetail.TryGet(rule.Operation, out var optionName))
            {
                var optionRect = new Rect(rect.x + rect.width / 2, rect.y, rect.width / 2, rect.height);
                var labelRect = new Rect(optionRect.x, optionRect.y, optionRect.width / 2, optionRect.height);
                var valueRect = new Rect(optionRect.x + optionRect.width / 2, optionRect.y, optionRect.width / 2, optionRect.height);
                EditorGUI.LabelField(labelRect, optionName);
                rule.StringOption = EditorGUI.TextField(valueRect, rule.StringOption);
            }
        }

        public override void OnGUI(string searchContext)
        {
            using (var check = new EditorGUI.ChangeCheckScope())
            {
                var settings = DroppedObjectOrderRuleSettings.instance;
                settings.Enable = EditorGUILayout.Toggle("Enable", settings.Enable);

                _reorderableList.DoLayoutList();

                if (check.changed)
                {
                    settings.Save();
                }
            }

            EditorGUILayout.HelpBox("Only executed when dragging and dropping an object onto the SceneView. Operations are performed in order from top to bottom.", MessageType.None);
        }
    }
}
