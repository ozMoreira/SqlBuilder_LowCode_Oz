using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SmartBuilder_POC.Helpers.UI
{
    public static class ConditionPanelBuilder
    {
        public static FlowLayoutPanel Create(
            List<string> availableFields,
            Action<FlowLayoutPanel> onRemoveCallback = null)
        {
            var panel = new FlowLayoutPanel
            {
                Width = 400,
                Height = 30,
                Margin = new Padding(3),
                AutoSize = true
            };

            var cmbField = new ComboBox
            {
                Width = 120,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbField.Items.AddRange(availableFields.ToArray());
            if (cmbField.Items.Count > 0)
                cmbField.SelectedIndex = 0;

            var cmbOperator = new ComboBox
            {
                Width = 80,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbOperator.Items.AddRange(new[] {
                "=", ">", "<", "<=", ">=", "<>", "!=", "LIKE", "NOT LIKE",
                "IN", "NOT IN", "BETWEEN", "IS NULL", "IS NOT NULL"
            });
            cmbOperator.SelectedIndex = 0;

            var btnRemove = new Button
            {
                Text = "🗑",
                Width = 30
            };
            btnRemove.Click += (s, e) => onRemoveCallback?.Invoke(panel);

            // Troca dinâmica do tipo de valor conforme operador
            cmbOperator.SelectedIndexChanged += (s, e) =>
            {
                string op = cmbOperator.SelectedItem.ToString();

                while (panel.Controls.Count > 2)
                    panel.Controls.RemoveAt(2);

                if (op == "IS NULL" || op == "IS NOT NULL")
                {
                    // Nenhum campo adicional
                }
                else if (op == "BETWEEN")
                {
                    panel.Controls.Add(new Label { Text = "From", AutoSize = true });
                    panel.Controls.Add(new TextBox { Width = 60 });
                    panel.Controls.Add(new Label { Text = "To", AutoSize = true });
                    panel.Controls.Add(new TextBox { Width = 60 });
                }
                else if (op == "IN" || op == "NOT IN")
                {
                    var txt = new TextBox
                    {
                        Width = 150,
                        Text = "value1, value2, value3",
                        ForeColor = Color.Gray
                    };

                    txt.GotFocus += (s2, e2) =>
                    {
                        if (txt.Text == "value1, value2, value3")
                        {
                            txt.Text = "";
                            txt.ForeColor = Color.Black;
                        }
                    };

                    txt.LostFocus += (s2, e2) =>
                    {
                        if (string.IsNullOrWhiteSpace(txt.Text))
                        {
                            txt.Text = "value1, value2, value3";
                            txt.ForeColor = Color.Gray;
                        }
                    };

                    panel.Controls.Add(txt);
                }
                else
                {
                    panel.Controls.Add(new TextBox { Width = 100 });
                }

                panel.Controls.Add(btnRemove);
            };

            panel.Controls.Add(cmbField);
            panel.Controls.Add(cmbOperator);
            panel.Controls.Add(new TextBox { Width = 100 });
            panel.Controls.Add(btnRemove);

            return panel;
        }
    }
}
