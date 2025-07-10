using SmartBuilder_POC.Helpers.UI;
using SmartBuilder_POC.Services;
using SmartBuilder_POC.Services.SqlConditions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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

        private void AddConditionPanel()
        {
            var panel = ConditionPanelBuilder.Create(
                AvailableFields,
                pnl => pnlWhereConditions.Controls.Remove(pnl),  // remove
                () => AddConditionPanel()                        // onAddNext: reentra aqui
            );
            pnlWhereConditions.Controls.Add(panel);
        }
        public string BuildWhereClause(string alias)
        {
            var parts = new List<string>();
            bool isFirst = true;

            foreach (FlowLayoutPanel panel in pnlWhereConditions.Controls.OfType<FlowLayoutPanel>())
            {
                // 0 = lógica, 1 = campo, 2 = operador, 3+ = TextBoxes
                var cmbLogic = panel.Controls.OfType<ComboBox>().ElementAt(0);
                var cmbField = panel.Controls.OfType<ComboBox>().ElementAt(1);
                var cmbOperator = panel.Controls.OfType<ComboBox>().ElementAt(2);

                string field = cmbField.SelectedItem?.ToString();
                string op = cmbOperator.SelectedItem?.ToString();
                if (string.IsNullOrWhiteSpace(field) || string.IsNullOrWhiteSpace(op))
                    continue;

                var values = panel.Controls
                                  .OfType<TextBox>()
                                  .Select(txt => txt.Text.Trim())
                                  .Where(txt => !string.IsNullOrEmpty(txt))
                                  .ToArray();

                if (!ConditionOperatorHandlerRegistry.TryGetHandler(op, out var handler))
                    continue;

                // Gera algo como "field BETWEEN 1 AND 10"
                string raw = handler.BuildSqlCondition(field, values).Trim();

                // Prefixa o alias no começo de cada cláusula
                // Ex: "A.field BETWEEN 1 AND 10"
                string aliased = raw.StartsWith(field + ".")
                    ? raw
                    : raw.Replace(field, $"{alias}.{field}");

                // Primeiro sem lógica, depois com AND/OR
                if (isFirst)
                {
                    parts.Add(aliased);
                    isFirst = false;
                }
                else
                {
                    parts.Add($"{cmbLogic.SelectedItem} {aliased}");
                }
            }

            // Junta tudo num único bloco:
            // Ex: "A.x = 1 OR A.y > 2 AND A.z IS NULL"
            return string.Join(" ", parts);
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {

        }
    }
}
