namespace DroppedObjectOrderRule
{
    public enum OrderRuleOperation
    {
        MoveToFirst = 0,
        MoveToLast = 1,
        MoveIntoObject = 2,
    }

    public class OrderRuleOperationOptionDetail
    {
        private static (OrderRuleOperation, string)[] Details = new (OrderRuleOperation, string)[]
        {
            (OrderRuleOperation.MoveIntoObject, "Object Name"),
        };

        public static bool TryGet(OrderRuleOperation operation, out string detail)
        {
            foreach (var (op, d) in Details)
            {
                if (op == operation)
                {
                    detail = d;
                    return true;
                }
            }
            detail = null;
            return false;
        }
    }
}
