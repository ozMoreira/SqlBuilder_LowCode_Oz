using System.Linq;

namespace SmartBuilder_POC.Services.SqlConditions
{
    public class InOperatorHandler : IConditionOperatorHandler
    {
        public string OperatorSymbol { get; }

        public InOperatorHandler(string op)
        {
            OperatorSymbol = op;
        }

        public string BuildSqlCondition(string field, params string[] values)
        {
            if (values == null || values.Length == 0 || string.IsNullOrWhiteSpace(values[0]))
                return string.Empty;

            var valueList = values[0]
                .Split(',')
                .Select(v => $"'{v.Trim()}'");

            return $"{field} {OperatorSymbol} ({string.Join(", ", valueList)})";
        }
    }
}
