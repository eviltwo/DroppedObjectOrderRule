using UnityEngine;

namespace DroppedObjectOrderRule.Operation
{
    public class MoveToLastOperation : IOperation
    {
        public bool Execute(GameObject gameObject)
        {
            gameObject.transform.SetAsLastSibling();
            return true;
        }
    }
}
