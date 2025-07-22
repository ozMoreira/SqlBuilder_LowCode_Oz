using MaterialSkin;
using SmartBuilder_POC.Controls;
using SmartBuilder_POC.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartBuilder_POC.Forms
{
    public partial class VisualSqlBuilderForm : MaterialSkin.Controls.MaterialForm
    {
        private readonly IDatabaseSchemaProvider _db;

        public string SelectedTable => cmbTabelas.SelectedItem?.ToString();
        public VisualSqlBuilderForm(string connectionString)
        {
            InitializeComponent();
            IDatabaseSchemaProvider schemaProvider = new DatabaseExplorer(connectionString);

            _db = schemaProvider;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800,   // azul escuro acinzentado
                Primary.BlueGrey900,   // sombra ainda mais escura
                Primary.BlueGrey500,   // claro (opcional)
                Accent.LightBlue200,   // destaque (botões de check, foco, etc.)
                TextShade.WHITE);

            pnlCanvas.AllowDrop = true;
            LoadPalette();
            CarregarTabelas();
            pnlCanvas.DragEnter += PnlCanvas_DragEnter;
            pnlCanvas.DragDrop += PnlCanvas_DragDrop;

        }

        private void LoadPalette()
        {
            var preview = new SelectBlockControl
            {
                Location = new Point(20, 20)
            };

            // Evento no preview (área azul "vazia")
            preview.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                    DoDragDrop("SELECT", DragDropEffects.Copy);
            };

            // Evento na label interna do preview (área de texto)
            if (preview.Controls.Count > 0 && preview.Controls[0] is Label lbl)
            {
                lbl.MouseDown += (s, e) =>
                {
                    if (e.Button == MouseButtons.Left)
                        DoDragDrop("SELECT", DragDropEffects.Copy);
                };
            }

            pnlPallete.Controls.Add(preview);
        }

        private void PnlCanvas_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;

        }

        private void PnlCanvas_DragDrop(object sender, DragEventArgs e)
        {
            string tipo = e.Data.GetData(DataFormats.Text)?.ToString();
            if (tipo == "SELECT")
            {
                var block = new SelectBlockControl();
                Point pt = pnlCanvas.PointToClient(new Point(e.X, e.Y));
                block.Location = pt;
                pnlCanvas.Controls.Add(block);

                block.EnableMove();

                // Remove com botão direito
                block.MouseUp += (s2, e2) =>
                {
                    if (e2.Button == MouseButtons.Right)
                    {
                        pnlCanvas.Controls.Remove(block);
                        block.Dispose();
                    }
                };
                // Remove com botão direito na label também
                foreach (Control c in block.Controls)
                {
                    c.MouseUp += (s2, e2) =>
                    {
                        if (e2.Button == MouseButtons.Right)
                        {
                            pnlCanvas.Controls.Remove(block);
                            block.Dispose();
                        }
                    };
                }
            }
        }

        private void Block_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var block = (sender as Control).Parent as Control ?? (sender as Control);
                if (MessageBox.Show("Remover bloco?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    pnlCanvas.Controls.Remove(block);
                    block.Dispose();
                }
            }
        }



        private void BtnGenerateSql_Click(object sender, EventArgs e)
        {
            string sql = "-- Blocos no canvas:\n";
            foreach (Control ctrl in pnlCanvas.Controls)
            {
                sql += ctrl.GetType().Name + "\n";
            }

            MessageBox.Show(sql, "SQL Gerado");
        }

        private void pnlPallete_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void CarregarTabelas()
        {
            // Use seu DatabaseExplorer/serviço de banco
            var tables = _db.GetTabelas();
            cmbTabelas.Items.Clear();
            cmbTabelas.Items.AddRange(tables.ToArray());
        }
    }
}
