using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SmartBuilder_POC.Controls
{
    public partial class TableBlockControl : UserControl
    {
        private bool _dragging;
        private Point _dragOffset;

        public string TableName { get; }
        public ListBox FieldList { get; }

        public TableBlockControl(string tableName, string[] fields)
        {
            TableName = tableName;
            this.Width = 160;
            this.Height = 220;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = Color.LightGray;
            this.AutoScaleMode = AutoScaleMode.None;

            //Cria Cabeçalho
            var header = new Label
            {
                Text = tableName,
                Dock = DockStyle.Top,
                Height = 12,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.DarkSlateGray,
                ForeColor = Color.WhiteSmoke
            };
            this.Controls.Add(header);

            FieldList = new ListBox
            {
                Dock = DockStyle.Fill,
                SelectionMode = SelectionMode.MultiSimple
            };
            FieldList.Items.AddRange(fields);
            this.Controls.Add(FieldList);

            // Eventos de drag
            this.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    _dragging = true;
                    _dragOffset = e.Location;
                    this.BringToFront();
                }
            };
            this.MouseMove += (s, e) =>
            {
                if (_dragging)
                {
                    this.Left = this.Left + e.X - _dragOffset.X;
                    this.Top = this.Top + e.Y - _dragOffset.Y;
                }
            };
            this.MouseUp += (s, e) => _dragging = false;
        }

        public string[] GetSelectedFields() =>
            FieldList.SelectedItems.Cast<string>().ToArray();
    }
}
