using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartBuilder_POC.Services.SqlConditions
{
    public class SimpleValueOperatorHandler : IConditionOperatorHandler
    {
        public string OperatorSymbol { get; }

        public SimpleValueOperatorHandler(string op)
        {
            OperatorSymbol = op;
        }

        public IEnumerable<Control> CreateValueControls()
        {
            yield return new TextBox { Width = 100 };
        }
    }
}
