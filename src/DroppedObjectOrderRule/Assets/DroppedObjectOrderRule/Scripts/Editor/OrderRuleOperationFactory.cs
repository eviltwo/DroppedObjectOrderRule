using DroppedObjectOrderRule.Operation;
using UnityEngine;

namespace DroppedObjectOrderRule
{
    public static class OrderRuleOperationFactory
    {
        public static IOperation CreateOperation(OrderRuleOperationArgument rule)
        {
            switch (rule.Operation)
            {
                case OrderRuleOperation.MoveToFirst:
                    return new MoveToFirstOperation();
                case OrderRuleOperation.MoveToLast:
                    return new MoveToLastOperation();
                case OrderRuleOperation.MoveIntoObject:
                    return new MoveIntoObjectOperation(rule.StringOption);
                default:
                    Debug.LogError($"Unknown operation: {rule.Operation}");
                    return null;
            }
        }
    }
}
