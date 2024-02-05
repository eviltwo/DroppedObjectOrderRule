using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DroppedObjectOrderRule
{
    [InitializeOnLoad]
    public static class SiblingIndexChanger
    {
        private static bool _hasLastEventType;
        private static EventType _lastEventType;
        private static List<GameObject> _goBuffer = new List<GameObject>();

        static SiblingIndexChanger()
        {
            ObjectChangeEvents.changesPublished += OnChangesPublished;
            SceneView.duringSceneGui += OnSceneGUI;
        }

        private static void OnChangesPublished(ref ObjectChangeEventStream stream)
        {
            if (!DroppedObjectOrderRuleSettings.instance.Enable)
            {
                return;
            }

            if (!_hasLastEventType)
            {
                return;
            }

            if (_lastEventType != EventType.DragPerform)
            {
                _hasLastEventType = false;
                return;
            }

            GetCreatedGameObjectsOnRoot(stream, _goBuffer);
            var count = _goBuffer.Count;
            for (int i = 0; i < count; i++)
            {
                ChangeSiblingIndexToLast(_goBuffer[i]);
            }

            _hasLastEventType = false;
        }

        private static void GetCreatedGameObjectsOnRoot(ObjectChangeEventStream stream, List<GameObject> results)
        {
            results.Clear();
            var length = stream.length;
            for (int i = 0; i < length; i++)
            {
                if (stream.GetEventType(i) == ObjectChangeKind.CreateGameObjectHierarchy)
                {
                    stream.GetCreateGameObjectHierarchyEvent(i, out var args);
                    var gameObject = EditorUtility.InstanceIDToObject(args.instanceId) as GameObject;
                    if (gameObject != null && gameObject.transform.parent == null)
                    {
                        results.Add(gameObject);
                    }
                }
            }
        }

        private static void OnSceneGUI(SceneView sceneView)
        {
            if (!DroppedObjectOrderRuleSettings.instance.Enable)
            {
                return;
            }

            var e = Event.current;
            if (e == null)
            {
                _hasLastEventType = false;
                return;
            }

            _hasLastEventType = true;
            _lastEventType = e.type;
        }

        private static void ChangeSiblingIndexToLast(GameObject go)
        {
            var transform = go.transform;
            var objectCount = transform.parent == null ? go.scene.rootCount : transform.parent.childCount;
            transform.SetSiblingIndex(objectCount - 1);
        }
    }
}
