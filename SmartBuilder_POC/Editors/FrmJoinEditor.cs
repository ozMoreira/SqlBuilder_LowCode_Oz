using System;
using System.Collections.Generic;
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

        public string SourceTable => lblTableName1.Text;
        public string SourceField => lblOriginField.Text;
        public string TargetTable => cmbTargetTable.SelectedItem?.ToString();
        public string TargetField => cmbTargetField.SelectedItem?.ToString();
        public string JoinType => cmbJoinType.SelectedItem?.ToString();

        public FrmJoinEditor(
            Dictionary<string,
            TabelaInfo> tabelasComCampos,
            string origemTable,
            string origemAlias,
            string origemCampo)
        {
            InitializeComponent();

            foreach (var item in tabelasComCampos)
            {
                string display = $"{item.Value.Alias} - {item.Key}";
                cmbTargetTable.Items.Add(display);
            }

            // Seleciona origem (e bloqueia edição)
            string origemDisplay = $"{origemAlias} - {origemTable}";
            lblTableName1.Text = origemDisplay;

            // Preenche campos de origem
            lblOriginField.Text = origemCampo;

            // Preenche TargetTable (não permite escolher a mesma tabela da origem)
            for (int i = cmbTargetTable.Items.Count - 1; i >= 0; i--)
            {
                if (cmbTargetTable.Items[i].ToString() == origemDisplay)
                    cmbTargetTable.Items.RemoveAt(i);
            }
            if (cmbTargetTable.Items.Count > 0)
                cmbTargetTable.SelectedIndex = 0;

            cmbJoinType.Items.AddRange(new[] { "INNER JOIN", "LEFT JOIN", "RIGHT JOIN", "FULL JOIN" });
            cmbJoinType.SelectedIndex = 0;

            cmbTargetField.Items.Clear();
            if (cmbTargetTable.SelectedItem != null)
            {
                // Separe o nome real da tabela de destino (após o hífen e espaço)
                string targetTable = cmbTargetTable.SelectedItem.ToString().Split(new[] { " - " }, 2, StringSplitOptions.None)[1];
                cmbTargetField.Items.AddRange(tabelasComCampos[targetTable].Campos.ToArray());
                if (cmbTargetField.Items.Count > 0)
                    cmbTargetField.SelectedIndex = 0;
            }

        }

    }
}
