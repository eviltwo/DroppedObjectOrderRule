using UnityEngine;

namespace DroppedObjectOrderRule.Operation
{
    public class MoveIntoObjectOperation : IOperation
    {
        private readonly string _objectName;

        public MoveIntoObjectOperation(string objectName)
        {
            _objectName = objectName;
        }

        public bool Execute(GameObject gameObject)
        {
            var rootObjects = gameObject.scene.GetRootGameObjects();
            var count = rootObjects.Length;
            for (int i = 0; i < count; i++)
            {
                var rootObject = rootObjects[i];
                if (rootObject.name == _objectName)
                {
                    gameObject.transform.SetParent(rootObject.transform);
                    return true;
                }
            }

            return false;
        }
    }
}
