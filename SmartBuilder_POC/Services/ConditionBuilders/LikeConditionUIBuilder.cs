using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartBuilder_POC.Services.ConditionBuilders
{
    public class LikeConditionUIBuilder : IConditionUIBuilder
    {
        public IEnumerable<Control> Build()
        {
            yield return new TextBox { Width = 120 };
        }
    }
}
