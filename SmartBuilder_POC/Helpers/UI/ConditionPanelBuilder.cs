using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartBuilder_POC.Helpers.UI
{
    public static class ConditionPanelBuilder
    {
        public static FlowLayoutPanel Create(
            List<string> availableFields,
            Action<FlowLayoutPanel> onRemoveCallback = null, Action onAddNext = null)
        {
            var panel = new FlowLayoutPanel
            {
                Width = 250,
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
                Width = 120,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbOperator.Items.AddRange(ConditionUIBuilderRegistry.GetSupportedOperators());
            cmbOperator.SelectedIndex = 0;

            var cmbLogic = new ComboBox
            {
                Width = 80,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbLogic.Items.AddRange(new[] { "", "AND", "OR" });
            cmbLogic.SelectedIndex = 0;
            cmbLogic.SelectedIndexChanged += (s, e) =>
            {
                if (cmbLogic.SelectedIndex > 0)
                {
                    onAddNext?.Invoke();
                }
            };

            var btnRemove = new Button
            {
                Text = "🗑",
                Width = 30
            };
            btnRemove.Click += (s, e) => onRemoveCallback?.Invoke(panel);

            // Handler para mudança de operador
            cmbOperator.SelectedIndexChanged += (s, e) =>
            {
                // Limpa a partir do índice 2 (0=cmbLogic,1=cmbField,2=cmbOperator)
                while (panel.Controls.Count > 3)
                    panel.Controls.RemoveAt(3);

                var builder = ConditionUIBuilderRegistry.GetBuilder(cmbOperator.SelectedItem.ToString());
                foreach (var ctrl in builder.Build())
                    panel.Controls.Add(ctrl);

                panel.Controls.Add(btnRemove);
            };


            panel.Controls.Add(cmbField);
            panel.Controls.Add(cmbOperator);
            

            // Valor inicial
            var initialBuilder = ConditionUIBuilderRegistry.GetBuilder(cmbOperator.SelectedItem.ToString());
            foreach (var ctrl in initialBuilder.Build())
                panel.Controls.Add(ctrl);

            // Botão remover
            panel.Controls.Add(cmbLogic);
            panel.Controls.Add(btnRemove);
            return panel;
        }
    }
}
