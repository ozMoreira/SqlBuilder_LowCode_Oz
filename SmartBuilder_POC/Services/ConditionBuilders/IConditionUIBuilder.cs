using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartBuilder_POC.Services.ConditionBuilders
{
    public interface IConditionUIBuilder
    {
        IEnumerable<Control> Build();
    }
}

