using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartBuilder_POC.Services.ConditionBuilders
{
    public class SimpleValueConditionUIBuilder : IConditionUIBuilder
    {
        public IEnumerable<Control> Build()
        {
            return new Control[]
            {
                new TextBox { Width = 150 }
            };
        }
    }
}
