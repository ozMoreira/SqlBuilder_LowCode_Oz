using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SmartBuilder_POC.Services.SqlConditions
{
    public class NullOperatorHandler : IConditionOperatorHandler
    {
        public string OperatorSymbol { get; }

        public NullOperatorHandler(string op)
        {
            OperatorSymbol = op;
        }

        public IEnumerable<Control> CreateValueControls()
        {
            return Enumerable.Empty<Control>();
        }
    }
}
