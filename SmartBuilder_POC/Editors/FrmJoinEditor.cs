using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SmartBuilder_POC.Editors
{
    public partial class FrmJoinEditor : Form
    {
        public class TabelaInfo
        {
            public string Alias { get; set; }
            public List<string> Campos { get; set; }
        }
        private readonly Dictionary<string, TabelaInfo> _tabelas;

        public string SourceTable { get; private set; }
        public string SourceAlias { get; private set; }
        public string SourceField { get; private set; }
        public string TargetTable { get; private set; }
        public string TargetAlias { get; private set; }
        public string TargetField { get; private set; }
        public string JoinType { get; private set; }

        public FrmJoinEditor(
           Dictionary<string, TabelaInfo> tabelasComCampos,
           string initialSourceTable,
           string initialSourceAlias,
           string initialSourceField)
        {
            InitializeComponent();
            _tabelas = tabelasComCampos;
            lblTableName1.Text = $"{initialSourceAlias} – {initialSourceTable}";
            lblOriginField.Text = initialSourceField;

            SourceTable = initialSourceTable;
            SourceAlias = initialSourceAlias;
            SourceField = initialSourceField;

            cmbJoinType.Items.AddRange(new[] {
                "INNER JOIN", "LEFT JOIN", "RIGHT JOIN", "FULL JOIN"
            });
            cmbJoinType.SelectedIndex = 0;

            // 2) Popula combos de tabela (ex: "A - TB_LIVROS")
            var tableItems = _tabelas
                 .Select(kv => $"{kv.Value.Alias} - {kv.Key}")
                 .ToArray();
            cmbTargetTable.Items.AddRange(tableItems);
            cmbTargetTable.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTargetTable.SelectedIndexChanged += (s, e) => LoadTargetFields();

            var defaultIndex = Array.FindIndex(tableItems, t => !t.EndsWith(initialSourceTable));
            cmbTargetTable.SelectedIndex = defaultIndex >= 0 ? defaultIndex : 0;
            LoadTargetFields();

            btnOk.Click += (s, e) => OnOk();
            btnCancel.Click += (s, e) => this.Close();
        }

        private void LoadTargetFields()
        {
            cmbTargetField.Items.Clear();
            var txt = cmbTargetTable.SelectedItem as string;
            if (string.IsNullOrEmpty(txt)) return;

            // txt = "B - TB_AUTORES", split
            var parts = txt.Split(new[] { " - " }, 2, StringSplitOptions.None);
            var alias = parts[0];
            var table = parts[1];

            // popula campos
            var campos = _tabelas[table].Campos;
            cmbTargetField.Items.AddRange(campos.ToArray());
            cmbTargetField.DropDownStyle = ComboBoxStyle.DropDownList;
            if (cmbTargetField.Items.Count > 0)
                cmbTargetField.SelectedIndex = 0;
        }

        private void OnOk()
        {
            // lê destino
            var tp = (cmbTargetTable.SelectedItem as string)
                     .Split(new[] { " - " }, 2, StringSplitOptions.None);
            TargetAlias = tp[0];
            TargetTable = tp[1];
            TargetField = cmbTargetField.SelectedItem as string;

            JoinType = cmbJoinType.SelectedItem as string;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
