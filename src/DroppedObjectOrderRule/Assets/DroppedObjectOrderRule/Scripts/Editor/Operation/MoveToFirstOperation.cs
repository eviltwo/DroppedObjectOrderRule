using UnityEngine;

namespace DroppedObjectOrderRule.Operation
{
    public class MoveToFirstOperation : IOperation
    {
        public bool Execute(GameObject gameObject)
        {
            gameObject.transform.SetAsFirstSibling();
            return true;
        }
    }
}
