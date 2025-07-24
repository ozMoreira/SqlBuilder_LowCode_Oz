using SmartBuilder_POC.Editors;
using System;
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
        public string TableName { get; }
        public string TableAlias { get; }
        public string FilterOperator { get; set; }
        public string FilterValue { get; set; }
        public bool IsOrderBy { get; set; }
        public string OrderDirection { get; set; } // "ASC" ou "DESC"
        public bool IsGroupBy { get; set; }

        public event EventHandler OnSolicitarJoin;

        public FieldBlockControl(string fieldName, string tableAlias, string tableName, Color color)
        {
            FieldName = fieldName;
            TableAlias = tableAlias;
            TableName = tableName;
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

            // Context menu
            var contextMenu = new ContextMenuStrip();
            var filtroItem = new ToolStripMenuItem("Adicionar/Editar Filtro");
            filtroItem.Click += (s, e) => EditarFiltro();
            contextMenu.Items.Add(filtroItem);
            //this.ContextMenuStrip = contextMenu;

            contextMenu.Items.Add(new ToolStripSeparator());

            // Order By ASC
            var orderByAscItem = new ToolStripMenuItem("Ordenar crescente (ASC)");
            orderByAscItem.Click += (s, e) => { this.IsOrderBy = true; this.OrderDirection = "ASC"; DestacarOrdem(); };
            contextMenu.Items.Add(orderByAscItem);

            // Order By DESC
            var orderByDescItem = new ToolStripMenuItem("Ordenar decrescente (DESC)");
            orderByDescItem.Click += (s, e) => { this.IsOrderBy = true; this.OrderDirection = "DESC"; DestacarOrdem(); };
            contextMenu.Items.Add(orderByDescItem);

            // Remover ordenação
            var removeOrderByItem = new ToolStripMenuItem("Remover Ordenação");
            removeOrderByItem.Click += (s, e) => { this.IsOrderBy = false; this.OrderDirection = null; DestacarOrdem(); };
            contextMenu.Items.Add(removeOrderByItem);

            contextMenu.Items.Add(new ToolStripSeparator());

            // Group By
            var groupByItem = new ToolStripMenuItem("Agrupar (GROUP BY)");
            groupByItem.Click += (s, e) => { this.IsGroupBy = !this.IsGroupBy; DestacarGrupo(); };
            contextMenu.Items.Add(groupByItem);

            var removeGroupByItem = new ToolStripMenuItem("Remover Agrupamento");
            removeGroupByItem.Click += (s, e) => { this.IsGroupBy = false; DestacarGrupo(); };
            contextMenu.Items.Add(removeGroupByItem);

            contextMenu.Items.Add(new ToolStripSeparator());

            var joinItem = new ToolStripMenuItem("Relacionar Tabelas (JOIN)");
            joinItem.Click += (s, e) => OnSolicitarJoin?.Invoke(this, EventArgs.Empty);
            contextMenu.Items.Add(joinItem);

            this.ContextMenuStrip = contextMenu;

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

        private void EditarFiltro()
        {
            var filtroForm = new FrmFilterEditor(this.FilterOperator, this.FilterValue);
            if (filtroForm.ShowDialog() == DialogResult.OK)
            {
                this.FilterOperator = filtroForm.SelectedOperator;
                this.FilterValue = filtroForm.FilterValue;

                // Muda a cor do label/bloco se filtro ativo
                if (!string.IsNullOrWhiteSpace(this.FilterOperator))
                    this.Controls[0].BackColor = Color.Orange; // Muda só o label
                else
                    this.Controls[0].BackColor = Color.LightYellow;
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

        private void DestacarOrdem()
        {
            // Exemplo: borda azul para ORDER BY
            this.Controls[0].BackColor = IsOrderBy ? Color.LightBlue : Color.LightYellow;
        }
        private void DestacarGrupo()
        {
            // Exemplo: borda verde para GROUP BY
            this.Controls[0].ForeColor = IsGroupBy ? Color.DarkGreen : Color.Black;
        }
    }
}
