using SmartBuilder_POC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartBuilder_POC.Controls
{
    public partial class JoinBlockControl : UserControl
    {
        public event EventHandler<JoinBlock> JoinAdded;
        public JoinBlockControl()
        {
            InitializeComponent();
        }

        private void btnAddJoin_Click(object sender, EventArgs e)
        {
            // 1) Validações básicas
            if (cbxJoinType.SelectedItem == null ||
                cbxTable1.SelectedItem == null ||
                cbxCampo1.SelectedItem == null ||
                cbxTable2.SelectedItem == null ||
                cbxCampo2.SelectedItem == null)
            {
                MessageBox.Show("Preencha todos os campos de Join antes de adicionar.");
                return;
            }

            // 2) Extrai os valores selecionados
            // Converte o texto selecionado em JoinType
            var selectedJoinType = (JoinType)Enum.Parse(
                typeof(JoinType),
                cbxJoinType.SelectedItem.ToString()
            );

            var selectedTableA = cbxTable1.SelectedItem.ToString();
            var selectedColumnA = cbxCampo1.SelectedItem.ToString();
            var selectedTableB = cbxTable2.SelectedItem.ToString();
            var selectedColumnB = cbxCampo2.SelectedItem.ToString();

            // 3) Cria o bloco de join
            var joinBlock = new JoinBlock
            {
                Type = selectedJoinType,
                LeftTable = selectedTableA,
                LeftColumn = selectedColumnA,
                RightTable = selectedTableB,
                RightColumn = selectedColumnB
            };

            // 4) Dispara o evento para quem consome este controle
            JoinAdded?.Invoke(this, joinBlock);
        }
    }
}
