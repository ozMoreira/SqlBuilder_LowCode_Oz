using SmartBuilder_POC.Helpers.UI;
using SmartBuilder_POC.Services;
using SmartBuilder_POC.Services.SqlConditions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SmartBuilder_POC.Controls
{
    public partial class SelectedTableControl : UserControl
    {
        public string SelectedTable => cmbTable.SelectedItem?.ToString();
        public List<string> SelectedFields => clbFields.CheckedItems.Cast<string>().ToList();
        private List<string> AvailableFields = new List<string>();
        private readonly IDatabaseSchemaProvider _db;

        public event EventHandler RemoverSolicitado;

        public SelectedTableControl(IDatabaseSchemaProvider db)
        {
            InitializeComponent();
            _db = db;

            cmbTable.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTable.SelectedIndexChanged += OnTableChanged;

            // Sem duplicidade: ligue sempre o botão, mas deixaremos o cmbLogic cuidar de 'Add Next'
            btnAddCondition.Click += btnAddCondition_Click;
            btnRemove.Click += (s, e) => RemoverSolicitado?.Invoke(this, EventArgs.Empty);

            LoadTables();

            // Opcional: já seleciona a primeira tabela para popular AvailableFields
            if (cmbTable.Items.Count > 0)
            {
                cmbTable.SelectedIndex = 0;
                // OnTableChanged não dispara automaticamente quando você seta SelectedIndex em código,
                // então dispare manualmente:
                OnTableChanged(this, EventArgs.Empty);
            }
        }
        private void LoadTables()
        {
            var tables = _db.GetTabelas();
            cmbTable.Items.Clear();
            cmbTable.Items.AddRange(tables.ToArray());
        }

        private void OnTableChanged(object sender, EventArgs e)
        {
            clbFields.Items.Clear();
            pnlWhereConditions.Controls.Clear();

            AvailableFields.Clear();
            var table = cmbTable.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(table))
                return;

            var fields = _db.GetCampos(table);
            AvailableFields.AddRange(fields);

            foreach (var f in fields)
                clbFields.Items.Add(f);

            btnAddCondition.Enabled = AvailableFields.Any();
        }

        private void btnAddCondition_Click(object sender, EventArgs e)
        {
            AddConditionPanel();
        }

        private void AddConditionPanel(string logic = null)
        {
            var panel = ConditionPanelBuilder.Create(
                AvailableFields,
                pnl => pnlWhereConditions.Controls.Remove(pnl),  // remove
                op => AddConditionPanel(op));

            // Se vier lógica no primeiro bloco, guarda no Tag
            if (!string.IsNullOrEmpty(logic))
                panel.Tag = logic;

            pnlWhereConditions.Controls.Add(panel);
        }
        public string BuildWhereClause(string alias)
        {
            var parts = new List<string>();
            bool first = true;

            foreach (FlowLayoutPanel panel in pnlWhereConditions.Controls.OfType<FlowLayoutPanel>())
            {
                var cmbField = panel.Controls.OfType<ComboBox>().First(c => (string)c.Tag == "field");
                var cmbOperator = panel.Controls.OfType<ComboBox>().First(c => (string)c.Tag == "operator");
                var logicTag = panel.Tag as string;

                string field = cmbField.SelectedItem?.ToString();
                string op = cmbOperator.SelectedItem?.ToString();
                if (string.IsNullOrWhiteSpace(field) || string.IsNullOrWhiteSpace(op))
                    continue;

                var values = panel.Controls
                                  .OfType<TextBox>()
                                  .Select(t => t.Text.Trim())
                                  .Where(t => t != "")
                                  .ToArray();

                if (!ConditionOperatorHandlerRegistry.TryGetHandler(op, out var handler))
                    continue;

                // gera, por exemplo, "ID_AUTOR = '1'"
                string raw = handler.BuildSqlCondition(field, values).Trim();

                // prefixa todas as ocorrências de "FIELD" por "A.FIELD"
                string pattern = $@"\b{Regex.Escape(field.ToUpper())}\b";
                string replacement = $"{alias}.{field.ToUpper()}";
                // uppercase geral
                raw = raw.ToUpper();
                string aliased = Regex.Replace(raw, pattern, replacement);

                if (first)
                {
                    parts.Add(aliased);
                    first = false;
                }
                else
                {
                    // injeta AND/OR antes da condição
                    string logic = (logicTag ?? "AND").ToUpper();
                    parts.Add($"{logic} {aliased}");
                }
            }

            // retorna algo como "A.ID_AUTOR = '1' AND A.NM_AUTOR = '3' OR A.ID_AUTOR = '4'"
            return string.Join(" ", parts);
        }

    }
}
