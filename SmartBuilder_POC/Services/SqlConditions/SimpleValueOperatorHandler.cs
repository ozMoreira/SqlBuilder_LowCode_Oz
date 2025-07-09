namespace SmartBuilder_POC.Services.SqlConditions
{
    public class SimpleValueOperatorHandler : IConditionOperatorHandler
    {
        public string OperatorSymbol { get; }

        public SimpleValueOperatorHandler(string op)
        {
            OperatorSymbol = op;
        }

        public string BuildSqlCondition(string field, params string[] values)
        {
            if (values == null || values.Length == 0 || string.IsNullOrWhiteSpace(values[0]))
                return string.Empty;

            return $"{field} {OperatorSymbol} '{values[0]}'";
        }
    }
}
