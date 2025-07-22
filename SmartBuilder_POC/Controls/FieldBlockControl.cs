using System.Drawing;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;

namespace SmartBuilder_POC.Controls
{
    public partial class FieldBlockControl : UserControl
    {
        private bool dragging = false;
        private Point dragStart;
        public string FieldName { get; }
        public string TableAlias { get; }

        public FieldBlockControl(string fieldName, string tableAlias, Color color)
        {
            FieldName = fieldName;
            TableAlias = tableAlias;
            this.Size = new Size(120, 35);
            this.BackColor = Color.Transparent; // Painel transparente

            var lbl = new Label
            {
                Text = $"{tableAlias}.{fieldName}",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = color,              // <- Aqui usa a cor única
                ForeColor = Color.Black,      // Ajuste para boa leitura
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(lbl);
        }
        public void EnableMove()
        {
            this.MouseDown += FieldBlock_MouseDown;
            this.MouseMove += FieldBlock_MouseMove;
            this.MouseUp += FieldBlock_MouseUp;

            // Caso o bloco tenha filhos (ex: label ocupando tudo):
            foreach (Control c in this.Controls)
            {
                c.MouseDown += FieldBlock_MouseDown;
                c.MouseMove += FieldBlock_MouseMove;
                c.MouseUp += FieldBlock_MouseUp;
            }
        }

        private void FieldBlock_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                dragStart = e.Location;
                this.BringToFront();
            }
        }

        private void FieldBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                var parentPanel = this.Parent;
                if (parentPanel != null)
                {
                    Point newLocation = parentPanel.PointToClient(Control.MousePosition);
                    newLocation.Offset(-dragStart.X, -dragStart.Y);
                    this.Location = newLocation;
                }
            }
        }

        private void FieldBlock_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
