using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SmartBuilder_POC.Services.ConditionBuilders;
using SmartBuilder_POC.Services.SqlConditions;

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
                Width = 100,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbOperator.Items.AddRange(ConditionUIBuilderRegistry.GetSupportedOperators());
            cmbOperator.SelectedIndex = 0;

            var btnRemove = new Button
            {
                Text = "🗑",
                Width = 30
            };
            btnRemove.Click += (s, e) => onRemoveCallback?.Invoke(panel);

            // Handler para mudança de operador
            cmbOperator.SelectedIndexChanged += (s, e) =>
            {
                string selectedOp = cmbOperator.SelectedItem?.ToString() ?? "";

                while (panel.Controls.Count > 2)
                    panel.Controls.RemoveAt(2);

                var builder = ConditionUIBuilderRegistry.GetBuilder(selectedOp);
                foreach (var ctrl in builder.Build())
                    panel.Controls.Add(ctrl);

                panel.Controls.Add(btnRemove);
            };

            // Adiciona controles iniciais
            panel.Controls.Add(cmbField);
            panel.Controls.Add(cmbOperator);

            var initialBuilder = ConditionUIBuilderRegistry.GetBuilder(cmbOperator.SelectedItem?.ToString());
            foreach (var ctrl in initialBuilder.Build())
                panel.Controls.Add(ctrl);

            panel.Controls.Add(btnRemove);

            return panel;
        }
    }
}
