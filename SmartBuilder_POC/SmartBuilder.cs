using SmartBuilder_POC.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartBuilder_POC
{
    public partial class FrmSmartBuilder : Form
    {
        public FrmSmartBuilder()
        {
            InitializeComponent();
        }

        private void FrmSmartBuilder_Load(object sender, EventArgs e)
        {

            var selectBlock = new SelectBlockControl();
            selectBlock.Top = 10;
            selectBlock.Left = 10;
            pnlPalette.Controls.Add(selectBlock);

            pnlCanvas.AllowDrop = true;

            // Canvas aceita drops
            pnlCanvas.DragEnter += (s, ev) =>
            {
                if (ev.Data.GetDataPresent(typeof(SelectBlockControl)))
                    ev.Effect = DragDropEffects.Move;
            };

            pnlCanvas.DragDrop += (s, ev) =>
            {
                var ctrl = ev.Data.GetData(typeof(SelectBlockControl)) as SelectBlockControl;
                if (ctrl == null) return;

                // Se vier da paleta, criamos uma CÓPIA (não removemos da paleta)
                if (ctrl.Parent == pnlPalette)
                    ctrl = new SelectBlockControl();

                pnlCanvas.Controls.Add(ctrl);
                var pt = pnlCanvas.PointToClient(Cursor.Position);
                ctrl.Left = pt.X;
                ctrl.Top = pt.Y;
            };

            pnlCanvas.DragDrop += (s, ev) =>
            {
                if (ev.Data.GetDataPresent(typeof(SelectBlockControl)))
                {
                    var original = ev.Data.GetData(typeof(SelectBlockControl)) as SelectBlockControl;

                    SelectBlockControl novo;

                    // Se estiver arrastando da paleta (ou seja, precisa clonar)
                    if (original.Parent == pnlPalette)
                    {
                        novo = new SelectBlockControl(); // cria nova instância
                    }
                    else
                    {
                        novo = original; // está apenas reposicionando no canvas
                    }

                    if (!pnlCanvas.Controls.Contains(novo))
                    {
                        pnlCanvas.Controls.Add(novo);
                    }

                    var local = pnlCanvas.PointToClient(Cursor.Position);
                    novo.Left = local.X;
                    novo.Top = local.Y;
                }
            };
        }

        private void btnGenerateSql_Click(object sender, EventArgs e)
        {
            var textos = new List<string>();

            /*foreach (Control c in pnlCanvas.Controls)
            {
                if (c is SelectBlockControl sb)
                {
                    // Evita duplicatas acidentais
                    if (!textos.Contains(sb.Bloco.Conteudo))
                    {
                        textos.Add(sb.Bloco.Conteudo);
                    }
                }
            }*/

            txtSqlOut.Text = string.Join("\n", textos);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Deseja realmente limpar todos os blocos do Smart Builder?",
                "Confirmar limpeza",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                pnlCanvas.Controls.Clear();
                txtSqlOut.Text = string.Empty;
            }
        }
    }
}
