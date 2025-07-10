using MaterialSkin;
using SmartBuilder_POC.Controls;
using SmartBuilder_POC.Services;
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
            var tableControls = pnlTables.Controls
        .OfType<SelectedTableControl>()
        .Where(tc => !string.IsNullOrWhiteSpace(tc.SelectedTable))
        .ToList();

            if (!tableControls.Any())
            {
                txtSql.Text = "-- Nenhuma tabela selecionada.";
                return;
            }

            // 1) SELECT + FROM com aliases
            var selectFields = new List<string>();
            var aliasMap = new Dictionary<string, string>();
            char alias = 'A';

            foreach (var tc in tableControls)
            {
                if (!aliasMap.ContainsKey(tc.SelectedTable))
                    aliasMap[tc.SelectedTable] = alias++.ToString();

                var a = aliasMap[tc.SelectedTable];
                foreach (var f in tc.SelectedFields)
                    selectFields.Add($"{a}.{f}");
            }

            if (selectFields.Count == 0)
            {
                txtSql.Text = "-- Nenhum campo selecionado.";
                return;
            }

            string selectClause = $"SELECT {string.Join(", ", selectFields)} ";
            string fromClause = "FROM " +
                string.Join(", ", aliasMap.Select(kv => $"{kv.Key} {kv.Value}")) +
                " ";

            // 2) WHERE — cada bloco com AND/OR interno preservado
            var whereBlocks = new List<string>();
            foreach (var tc in tableControls)
            {
                var a = aliasMap[tc.SelectedTable];
                var block = tc.BuildWhereClause(a)?.Trim();
                if (!string.IsNullOrWhiteSpace(block))
                    whereBlocks.Add($"({block})");  // opcional: parênteses para cada tabela
            }

            string whereClause = whereBlocks.Any()
                ? "WHERE " + string.Join(" AND ", whereBlocks)
                : "";

            // 3) Monta o SQL final
            txtSql.Text = $"{selectClause}\n{fromClause}"
                        + (string.IsNullOrEmpty(whereClause)
                            ? ""
                            : "\n" + whereClause);

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            SqlQueryBuilderService.ClearSqlOutput(txtSql);
        }
    }
}
