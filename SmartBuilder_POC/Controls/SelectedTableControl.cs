using SmartBuilder_POC.Helpers.UI;
using SmartBuilder_POC.Services;
using SmartBuilder_POC.Services.SqlConditions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            btnRemove.Click += (s, e) => RemoverSolicitado?.Invoke(this, EventArgs.Empty);
            LoadTables();
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
            AvailableFields.Clear();
            var table = SelectedTable;
            if (string.IsNullOrEmpty(table)) return;

            var fields = _db.GetCampos(table);
            AvailableFields.AddRange(fields);
            foreach (var f in fields)
                clbFields.Items.Add(f);
        }

        private void btnAddCondition_Click(object sender, EventArgs e)
        {
            var panel = ConditionPanelBuilder.Create(
                AvailableFields,
                pnl => pnlWhereConditions.Controls.Remove(pnl));
            pnlWhereConditions.Controls.Add(panel);
        }

        public List<string> GetSqlConditions()
        {
            var clauses = new List<string>();
            foreach (FlowLayoutPanel pnl in pnlWhereConditions.Controls.OfType<FlowLayoutPanel>())
            {
                var cmbField = pnl.Controls.OfType<ComboBox>().FirstOrDefault();
                var cmbOp = pnl.Controls.OfType<ComboBox>().Skip(1).FirstOrDefault();
                if (cmbField == null || cmbOp == null) continue;

                string field = cmbField.SelectedItem?.ToString();
                string op = cmbOp.SelectedItem?.ToString();
                var values = pnl.Controls.OfType<TextBox>()
                                    .Select(t => t.Text.Trim())
                                    .Where(t => !string.IsNullOrEmpty(t))
                                    .ToArray();

                if (ConditionOperatorHandlerRegistry.TryGetHandler(op, out var handler))
                {
                    var clause = handler.BuildSqlCondition(field, values);
                    if (!string.IsNullOrWhiteSpace(clause))
                        clauses.Add(clause);
                }
            }
            return clauses;
        }
    }
}
