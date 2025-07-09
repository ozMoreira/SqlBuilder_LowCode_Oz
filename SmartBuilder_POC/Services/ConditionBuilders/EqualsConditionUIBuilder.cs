using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartBuilder_POC.Services.ConditionBuilders
{
    public class EqualsConditionUIBuilder : IConditionUIBuilder
    {
        public IEnumerable<Control> Build()
        {
            return new Control[]
            {
                new TextBox { Width = 100 }
            };
        }
    }
}
