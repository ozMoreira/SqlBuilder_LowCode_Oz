using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartBuilder_POC.Services.SqlConditions
{
    public interface IConditionOperatorHandler
    {
        string OperatorSymbol { get; }
        string BuildSqlCondition(string field, params string[] values);
    }
}
