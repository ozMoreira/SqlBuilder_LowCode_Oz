using System;

namespace SmartBuilder_POC.Services.SqlConditions
{
    public class BetweenOperatorHandler : IConditionOperatorHandler
    {
        public string OperatorSymbol => "BETWEEN";

        public string BuildSqlCondition(string field, params string[] values)
        {
            if (values == null || values.Length < 2)
                return $"{field} BETWEEN ... AND ...";

            string start = values[0];
            string end = values[1];

            return $"{field} BETWEEN {FormatValue(start)} AND {FormatValue(end)}";
        }

        private string FormatValue(string value)
        {
            // Aqui você pode expandir para tratar números, datas etc.
            return $"'{value}'";
        }
    }
}
