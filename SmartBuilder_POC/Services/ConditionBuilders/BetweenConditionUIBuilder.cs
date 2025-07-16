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
                new Label { Text = "valor inicial", AutoSize = true },
                new TextBox { Width = 150 },
                new Label { Text = "valor final", AutoSize = true },
                new TextBox { Width = 150 }
            };
        }
    }
}
