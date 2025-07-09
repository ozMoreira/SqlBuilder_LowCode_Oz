using System.Windows.Forms;
using SmartBuilder_POC.Models;

namespace SmartBuilder_POC.Controls
{
    public partial class SelectBlockControl : UserControl
    {
        public SqlBlock Bloco { get; }
        public SelectBlockControl()
        {
            InitializeComponent();

            // Criamos o modelo associado
            Bloco = new SqlBlock
            {
                Tipo = "SELECT",
                Conteudo = "SELECT * FROM TABELA"
            };

            lblSelect.Text = Bloco.Conteudo;

            // Habilita arrastar
            this.MouseDown += (s, e) =>
            {
                DoDragDrop(this, DragDropEffects.Move);
            };

            this.MouseDown += Block_MouseDown;
            lblSelect.MouseDown += Block_MouseDown;
        }

        private void Block_MouseDown(object sender, MouseEventArgs e)
        {
            DoDragDrop(this, DragDropEffects.Move);
        }
    }
}
