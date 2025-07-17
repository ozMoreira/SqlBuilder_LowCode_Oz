using System.Drawing;
using System.Windows.Forms;
using static SmartBuilder_POC.Services.SqlQueryBuilderService;

namespace SmartBuilder_POC.Controls
{
    public partial class ConnectorPoint : UserControl
    {
        public TableBlockControl ParentBlock { get; }
        public string FieldName { get; }

        public ConnectorPoint(TableBlockControl parent, string field)
        {
            InitializeComponent();
            ParentBlock = parent;
            FieldName = field;
            var bmp = new Bitmap(12, 12);
            using (var g = Graphics.FromImage(bmp))
                g.FillEllipse(Brushes.Black, 0, 0, 11, 11);

            // Exibe um pequeno círculo (definido no Designer ou em Resources)
            pictureBox1.Image = bmp;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Cursor = Cursors.Hand;

            // Tamanho do UserControl igual ao PictureBox
            this.Width = pictureBox1.Width;
            this.Height = pictureBox1.Height;

            // Clique dispara evento no form
            pictureBox1.Click += (s, e) => OnClick(e);
        }
    }
}
