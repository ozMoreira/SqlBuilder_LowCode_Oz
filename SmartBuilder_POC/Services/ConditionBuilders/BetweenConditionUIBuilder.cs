using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartBuilder_POC.Services.ConditionBuilders
{
    public class BetweenConditionUIBuilder : IConditionUIBuilder
    {
        public IEnumerable<Control> Build()
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
