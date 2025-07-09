using SmartBuilder_POC.Controls;
using SmartBuilder_POC.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartBuilder_POC.Editors
{
    public partial class SelectQueryBuilderForm : Form
    {
        private readonly DatabaseExplorer _db;
        public SelectQueryBuilderForm(string connectionString)
        {
            InitializeComponent();
            _db = new DatabaseExplorer(connectionString);
            btnAddTable_Click(null, EventArgs.Empty);
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            var bloco = new SelectedTableControl(_db);
            bloco.RemoverSolicitado += (s, ev) => pnlTables.Controls.Remove((Control)s);
            pnlTables.Controls.Add(bloco);
        }

        private void btnGenSql_Click(object sender, EventArgs e)
        {
            var campos = new List<string>();
            var tabelasUsadas = new HashSet<string>();

            foreach (Control c in pnlTables.Controls)
            {
                if (c is SelectedTableControl bloco)
                {
                    if (string.IsNullOrWhiteSpace(bloco.TabelaSelecionada)) continue;
                    tabelasUsadas.Add(bloco.TabelaSelecionada);

                    foreach (var campo in bloco.CamposSelecionados)
                        campos.Add($"{bloco.TabelaSelecionada}.{campo}");
                }
            }

            if (campos.Count == 0 || tabelasUsadas.Count == 0)
            {
                txtSql.Text = "-- Nenhuma tabela ou campo selecionado.";
                return;
            }

            string sql = $"SELECT {string.Join(", ", campos)}\n FROM {string.Join(", ", tabelasUsadas)}";
            txtSql.Text = sql;
        }
    }
}
