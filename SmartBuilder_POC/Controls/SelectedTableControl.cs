using SmartBuilder_POC.Helpers.UI;
using SmartBuilder_POC.Services;
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

        private readonly DatabaseExplorer _db;

        public event EventHandler RemoverSolicitado;

        public SelectedTableControl(DatabaseExplorer db)
        {
            InitializeComponent();
            _db = db;

            cmbTable.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTable.SelectedIndexChanged += CmbTabela_SelectedIndexChanged;
            btnRemove.Click += (s, e) => RemoverSolicitado?.Invoke(this, EventArgs.Empty);

            FeedTables();
        }

        private void FeedTables()
        {
            var tables = _db.GetTabelas();
            cmbTable.Items.AddRange(tables.ToArray());
        }

        private void CmbTabela_SelectedIndexChanged(object sender, EventArgs e)
        {
            clbFields.Items.Clear();
            var table = cmbTable.SelectedItem?.ToString();
            if (table == null) return;

            var fields = _db.GetCampos(table);
            foreach (var field in fields)
                clbFields.Items.Add(field);
        }

        private void btnAddCondition_Click(object sender, EventArgs e)
        {
            var conditionPanel = ConditionPanelBuilder.Create(
                AvailableFields,
                panel => pnlWhereConditions.Controls.Remove(panel));
            pnlWhereConditions.Controls.Add(conditionPanel);
        }


        private void cmbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            clbFields.Items.Clear();
            var tabela = cmbTable.SelectedItem?.ToString();
            if (tabela == null) return;

            var campos = _db.GetCampos(tabela);
            AvailableFields = campos;
            foreach (var campo in campos)
                clbFields.Items.Add(campo);
        }
    }
}
