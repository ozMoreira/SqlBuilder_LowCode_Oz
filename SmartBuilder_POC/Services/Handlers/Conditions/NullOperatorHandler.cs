namespace SmartBuilder_POC.Services.SqlConditions
{
    public class NullOperatorHandler : IConditionOperatorHandler
    {
        public string OperatorSymbol { get; }

        public NullOperatorHandler(string op)
        {
            OperatorSymbol = op;
        }

        public string BuildSqlCondition(string field, params string[] values)
        {
            return $"{field} {OperatorSymbol}";
        }
    }
}
