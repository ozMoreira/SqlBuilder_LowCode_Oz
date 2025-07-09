using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SmartBuilder_POC.Services.ConditionBuilders
{
    public class InConditionUIBuilder : IConditionUIBuilder
    {
        public IEnumerable<Control> Build()
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
