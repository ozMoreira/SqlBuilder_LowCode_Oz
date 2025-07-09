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
        public string TabelaSelecionada => cmbTable.SelectedItem?.ToString();
        public List<string> CamposSelecionados => clbFields.CheckedItems.Cast<string>().ToList();

        private readonly DatabaseExplorer _db;

        public event EventHandler RemoverSolicitado;

        public SelectedTableControl(DatabaseExplorer db)
        {
            InitializeComponent();
            _db = db;

            cmbTable.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTable.SelectedIndexChanged += CmbTabela_SelectedIndexChanged;
            btnRemove.Click += (s, e) => RemoverSolicitado?.Invoke(this, EventArgs.Empty);

            CarregarTabelas();
        }

        private void CarregarTabelas()
        {
            var tabelas = _db.GetTabelas();
            cmbTable.Items.AddRange(tabelas.ToArray());
        }

        private void CmbTabela_SelectedIndexChanged(object sender, EventArgs e)
        {
            clbFields.Items.Clear();
            var tabela = cmbTable.SelectedItem?.ToString();
            if (tabela == null) return;

            var campos = _db.GetCampos(tabela);
            foreach (var campo in campos)
                clbFields.Items.Add(campo);
        }
    }
}
