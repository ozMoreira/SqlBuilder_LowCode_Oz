using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace SmartBuilder_POC.Services.SqlConditions
{
    public class InOperatorHandler : IConditionOperatorHandler
    {
        public string OperatorSymbol { get; }

        public InOperatorHandler(string op)
        {
            OperatorSymbol = op;
        }

        public IEnumerable<Control> CreateValueControls()
        {
            var txt = new TextBox
            {
                Width = 150,
                Text = "value1, value2, value3",
                ForeColor = Color.Gray
            };

            txt.GotFocus += (s, e) =>
            {
                if (txt.Text == "value1, value2, value3")
                {
                    txt.Text = "";
                    txt.ForeColor = Color.Black;
                }
            };

            txt.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = "value1, value2, value3";
                    txt.ForeColor = Color.Gray;
                }
            };

            yield return txt;
        }
    }
}
