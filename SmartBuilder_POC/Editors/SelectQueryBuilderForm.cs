using MaterialSkin;
using SmartBuilder_POC.Controls;
using SmartBuilder_POC.Services;
using SmartBuilder_POC.Services.SqlConditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SmartBuilder_POC.Editors
{
    public partial class SelectQueryBuilderForm : MaterialSkin.Controls.MaterialForm
    {
        private readonly IDatabaseSchemaProvider _db;
        private int minFormWidth;

        public SelectQueryBuilderForm(string connectionString)
        {
            InitializeComponent();
            minFormWidth = this.Width; // guarda a largura inicial do form
            btnCopy.Text = "📋 Copiar";

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800,   // azul escuro acinzentado
                Primary.BlueGrey900,   // sombra ainda mais escura
                Primary.BlueGrey500,   // claro (opcional)
                Accent.LightBlue200,   // destaque (botões de check, foco, etc.)
                TextShade.WHITE);

            IDatabaseSchemaProvider schemaProvider = new DatabaseExplorer(connectionString);
            _db = schemaProvider;
            btnAddTables_Click(null, EventArgs.Empty);
        }

        private void btnAddTables_Click(object sender, EventArgs e)
        {
            var bloco = new SelectedTableControl(_db);
            bloco.RemoverSolicitado += (s, ev) =>
            {
                pnlTables.Controls.Remove((Control)s);
                this.BeginInvoke((MethodInvoker)delegate
                {
                    FormResizer.Adjust(this, pnlTables, tlpPrincipal, minFormWidth);
                }); // reduz tamanho se possível
            };

            pnlTables.Controls.Add(bloco);

            FormResizer.Adjust(this, pnlTables, tlpPrincipal, minFormWidth);
        }


        private void btnGenSql_Click(object sender, EventArgs e)
        {
            // 1) Reúna todos os SelectedTableControl
            var tableControls = pnlTables.Controls
                .OfType<SelectedTableControl>()
                .Where(tc => !string.IsNullOrWhiteSpace(tc.SelectedTable))
                .ToList();

            if (!tableControls.Any())
            {
                txtSql.Text = "-- Nenhuma tabela selecionada.";
                return;
            }

            // 2) Gere aliases (A, B, C…) para cada tabela
            var aliasMap = new Dictionary<string, string>();
            char nextAlias = 'A';
            foreach (var tc in tableControls)
                if (!aliasMap.ContainsKey(tc.SelectedTable))
                    aliasMap[tc.SelectedTable] = (nextAlias++).ToString();

            // 3) Monte o SELECT (campos em MAIÚSCULO)
            var selectFields = tableControls
                .SelectMany(tc =>
                    tc.SelectedFields
                      .Select(f => $"{aliasMap[tc.SelectedTable]}.{f.ToUpper()}")
                )
                .ToList();

            if (!selectFields.Any())
            {
                txtSql.Text = "-- Nenhum campo selecionado.";
                return;
            }

            string selectClause = $"SELECT {string.Join(", ", selectFields)}";
            string fromClause = "FROM " +
                string.Join(", ",
                    aliasMap.Select(kv => $"{kv.Key} {kv.Value}")
                );

            // 4) Monte o WHERE chamando o BuildWhereClause de cada controle
            var whereParts = tableControls
                .Select(tc => tc.BuildWhereClause(aliasMap[tc.SelectedTable]).Trim())
                .Where(w => !string.IsNullOrWhiteSpace(w))
                .ToList();

            string whereClause = whereParts.Any()
                ? "WHERE " + string.Join(" AND ", whereParts)
                : "";

            // 5) Exiba tudo junto
            txtSql.Text = selectClause
                        + "\n" + fromClause
                        + (string.IsNullOrEmpty(whereClause) ? "" : "\n" + whereClause);
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            SqlQueryBuilderService.ClearSqlOutput(txtSql);
        }
    }
}
