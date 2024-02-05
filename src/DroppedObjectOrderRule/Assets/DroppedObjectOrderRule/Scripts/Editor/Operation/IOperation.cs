using UnityEngine;

namespace DroppedObjectOrderRule.Operation
{
    public interface IOperation
    {
        /// <summary>
        /// Execute the operation.
        /// </summary>
        /// <returns>true: success</returns>
        bool Execute(GameObject gameObject);
    }
}
