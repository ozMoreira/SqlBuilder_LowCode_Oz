using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SmartBuilder_POC.Helpers.UI
{
    public static class JoinPanelBuilder
    {
        public static FlowLayoutPanel Create(
            IEnumerable<string> tables,
            Func<string, IEnumerable<string>> getFields,
            Action<FlowLayoutPanel> onRemove)
        {
            var panel = new FlowLayoutPanel
            {
                AutoSize = true,
                Margin = new Padding(3)
            };

            // Tipo de Join
            var cmbType = new ComboBox
            {
                Width = 100,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Tag = "joinType"
            };
            cmbType.Items.AddRange(new[] { "INNER JOIN", "LEFT JOIN", "RIGHT JOIN", "FULL JOIN" });
            cmbType.SelectedIndex = 0;
            panel.Controls.Add(cmbType);

            // Tabela Esquerda
            var cmbLeftTable = new ComboBox
            {
                Width = 120,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Tag = "leftTable"
            };
            cmbLeftTable.Items.AddRange(tables.ToArray());
            panel.Controls.Add(cmbLeftTable);

            // Campo Esquerdo
            var cmbLeftField = new ComboBox
            {
                Width = 120,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Tag = "leftField"
            };
            panel.Controls.Add(cmbLeftField);

            // Sinal “=”
            panel.Controls.Add(new Label { Text = "=", AutoSize = true });

            // Tabela Direita
            var cmbRightTable = new ComboBox
            {
                Width = 120,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Tag = "rightTable"
            };
            cmbRightTable.Items.AddRange(tables.ToArray());
            panel.Controls.Add(cmbRightTable);

            // Campo Direito
            var cmbRightField = new ComboBox
            {
                Width = 120,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Tag = "rightField"
            };
            panel.Controls.Add(cmbRightField);

            // Botão remover
            var btnRemove = new Button
            {
                Text = "🗑",
                Width = 30
            };
            btnRemove.Click += (s, e) => onRemove(panel);
            panel.Controls.Add(btnRemove);

            // Helper para (re)popular campos ao trocar tabela
            void PopulateFields(ComboBox tableCb, ComboBox fieldCb)
            {
                fieldCb.Items.Clear();
                var tbl = tableCb.SelectedItem as string;
                if (tbl != null)
                    fieldCb.Items.AddRange(getFields(tbl).ToArray());
                if (fieldCb.Items.Count > 0)
                    fieldCb.SelectedIndex = 0;
            }

            // Eventos
            cmbLeftTable.SelectedIndexChanged += (s, e) => PopulateFields(cmbLeftTable, cmbLeftField);
            cmbRightTable.SelectedIndexChanged += (s, e) => PopulateFields(cmbRightTable, cmbRightField);

            // Inicializa campos
            if (cmbLeftTable.Items.Count > 0)
                cmbLeftTable.SelectedIndex = 0;
            if (cmbRightTable.Items.Count > 0)
                cmbRightTable.SelectedIndex = 0;

            return panel;
        }
    }
}
