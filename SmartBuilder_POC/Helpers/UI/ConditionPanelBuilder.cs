using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SmartBuilder_POC.Services.ConditionBuilders;

namespace SmartBuilder_POC.Helpers.UI
{
    public static class ConditionPanelBuilder
    {
        public static FlowLayoutPanel Create(
            List<string> availableFields,
            Action<FlowLayoutPanel> onRemove,
            Action<string> onAddNext = null)
        {
            var panel = new FlowLayoutPanel
            {
                Width = 400,
                Height = 30,
                Margin = new Padding(3),
                AutoSize = true
            };

            // 1) Campo
            var cmbField = new ComboBox
            {
                Width = 150,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Tag = "field"
            };
            cmbField.Items.AddRange(availableFields.ToArray());
            if (cmbField.Items.Count > 0) cmbField.SelectedIndex = 0;
            panel.Controls.Add(cmbField);

            // 2) Operador
            var cmbOperator = new ComboBox
            {
                Width = 150,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Tag = "operator"
            };
            cmbOperator.Items.AddRange(ConditionUIBuilderRegistry.GetSupportedOperators());
            cmbOperator.SelectedIndex = 0;
            panel.Controls.Add(cmbOperator);

            // 3) Controles de valor iniciais
            var initialBuilder = ConditionUIBuilderRegistry.GetBuilder(cmbOperator.SelectedItem.ToString());
            foreach (var ctrl in initialBuilder.Build())
                panel.Controls.Add(ctrl);

            // 4) Botoes
            var btnRemove = new Button { Text = "🗑", Width = 45, Height =30,
                BackColor = Color.White,
                UseVisualStyleBackColor = false,
                FlatStyle = FlatStyle.Flat
            };
            btnRemove.Click += (s, e) => onRemove?.Invoke(panel);
      
            var btnAnd = new Button { Text = "E", Width = 45,
                Height = 30,
                Tag = "logic",
                BackColor = Color.White,
                UseVisualStyleBackColor = false,
                FlatStyle = FlatStyle.Flat
            };
            btnAnd.Click += (s, e) => onAddNext?.Invoke("AND");

            var btnOr = new Button { Text = "OU", Width = 45,
                Height = 30,
                Tag = "logic",
                BackColor = Color.White,         
                UseVisualStyleBackColor = false, 
                FlatStyle = FlatStyle.Flat
            };
            btnOr.Click += (s, e) => onAddNext?.Invoke("OR");

            // 5) Quando trocar operador, refaz controles de valor
            cmbOperator.SelectedIndexChanged += (s, e) => {
                // limpa tudo após campo(0) e operador(1)
                while (panel.Controls.Count > 2)
                    panel.Controls.RemoveAt(2);

                var builder = ConditionUIBuilderRegistry.GetBuilder(cmbOperator.SelectedItem.ToString());
                foreach (var ctrl in builder.Build())
                    panel.Controls.Add(ctrl);

                panel.Controls.Add(btnAnd);
                panel.Controls.Add(btnOr);
                panel.Controls.Add(btnRemove);
            };
    
            panel.Controls.Add(btnAnd);
            panel.Controls.Add(btnOr);
            panel.Controls.Add(btnRemove);

            return panel;
        }
    }
}
