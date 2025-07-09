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
            // 1) Monta a lista de blocks para o serviço
            var blocks = pnlTables.Controls
                .OfType<SelectedTableControl>()
                .Where(c => !string.IsNullOrWhiteSpace(c.SelectedTable))
                .Select(c => new SqlQueryBuilderService.TableBlock
                {
                    TableName = c.SelectedTable,
                    SelectedFields = c.SelectedFields,
                    WhereConditions = c.GetSqlConditions()  // usa o método que extrai as condições
                })
                .ToList();

            // 2) Gera o SQL completo (SELECT + FROM + WHERE) no serviço
            string sql = SqlQueryBuilderService.GenerateSelectQuery(blocks);

            // 3) Exibe no TextBox
            txtSql.Text = sql;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            SqlQueryBuilderService.ClearSqlOutput(txtSql);
        }
    }
}
