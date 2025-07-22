using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartBuilder_POC.Controls
{
    public partial class SelectBlockControl : UserControl
    {

        private bool _dragging = false;
        private Point _dragStart;
        public SelectBlockControl()
        {
            this.Size = new Size(140, 60);
            this.BackColor = Color.LightBlue;
            this.BorderStyle = BorderStyle.FixedSingle;

            var label = new Label
            {
                Text = "SELECT",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            this.Controls.Add(label);
        }

        public void EnableMove()
        {
            this.MouseDown += StartDrag;
            this.MouseMove += DoDrag;
            this.MouseUp += EndDrag;
            // Para a label também:
            foreach (Control c in this.Controls)
            {
                c.MouseDown += StartDrag;
                c.MouseMove += DoDrag;
                c.MouseUp += EndDrag;
            }
        }

        private void StartDrag(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _dragging = true;
                _dragStart = e.Location;
                this.BringToFront();
            }
        }

        private void DoDrag(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                var newLocation = this.Parent.PointToClient(MousePosition);
                newLocation.Offset(-_dragStart.X, -_dragStart.Y);
                this.Location = newLocation;
            }
        }

        private void EndDrag(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }
    }
}