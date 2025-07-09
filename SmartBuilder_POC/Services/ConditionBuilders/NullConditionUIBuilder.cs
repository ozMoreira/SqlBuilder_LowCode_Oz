using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartBuilder_POC.Services.ConditionBuilders
{
    public class NullConditionUIBuilder : IConditionUIBuilder
    {
        public IEnumerable<Control> Build()
        {
            yield break; // Nenhum campo para IS NULL / IS NOT NULL
        }
    }
}
