using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartBuilder_POC.Services.SqlConditions
{
    public class BetweenOperatorHandler : IConditionOperatorHandler
    {
        public string OperatorSymbol => "BETWEEN";

        public IEnumerable<Control> CreateValueControls()
        {
            return new Control[]
            {
                new Label { Text = "From", AutoSize = true },
                new TextBox { Width = 60 },
                new Label { Text = "to", AutoSize = true },
                new TextBox { Width = 60 }
            };
        }
    }
}
