namespace SmartBuilder_POC.Editors
{
    partial class SelectQueryBuilderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectQueryBuilderForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddTables = new MaterialSkin.Controls.MaterialFlatButton();
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTables = new System.Windows.Forms.FlowLayoutPanel();
            this.txtSql = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCopy = new FontAwesome.Sharp.IconButton();
            this.btnClear = new FontAwesome.Sharp.IconButton();
            this.btnGenSql = new FontAwesome.Sharp.IconButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.tlpPrincipal.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.36223F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.63777F));
            this.tableLayoutPanel1.Controls.Add(this.btnAddTables, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(387, 47);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // btnAddTables
            // 
            this.btnAddTables.AutoSize = true;
            this.btnAddTables.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddTables.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.btnAddTables.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddTables.Depth = 0;
            this.btnAddTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddTables.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTables.Location = new System.Drawing.Point(92, 10);
            this.btnAddTables.Margin = new System.Windows.Forms.Padding(10);
            this.btnAddTables.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddTables.Name = "btnAddTables";
            this.btnAddTables.Primary = false;
            this.btnAddTables.Size = new System.Drawing.Size(285, 27);
            this.btnAddTables.TabIndex = 3;
            this.btnAddTables.Text = "+ Adicionar Tabela";
            this.btnAddTables.UseVisualStyleBackColor = false;
            this.btnAddTables.Click += new System.EventHandler(this.btnAddTables_Click);
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.tlpPrincipal.ColumnCount = 2;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 453F));
            this.tlpPrincipal.Controls.Add(this.pnlTables, 0, 1);
            this.tlpPrincipal.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tlpPrincipal.Controls.Add(this.txtSql, 1, 1);
            this.tlpPrincipal.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tlpPrincipal.ForeColor = System.Drawing.Color.Navy;
            this.tlpPrincipal.Location = new System.Drawing.Point(3, 70);
            this.tlpPrincipal.Margin = new System.Windows.Forms.Padding(10);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 2;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 518F));
            this.tlpPrincipal.Size = new System.Drawing.Size(954, 574);
            this.tlpPrincipal.TabIndex = 5;
            // 
            // pnlTables
            // 
            this.pnlTables.AutoScroll = true;
            this.pnlTables.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.pnlTables.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTables.Location = new System.Drawing.Point(10, 63);
            this.pnlTables.Margin = new System.Windows.Forms.Padding(10);
            this.pnlTables.Name = "pnlTables";
            this.pnlTables.Size = new System.Drawing.Size(481, 501);
            this.pnlTables.TabIndex = 5;
            // 
            // txtSql
            // 
            this.txtSql.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.txtSql.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSql.Location = new System.Drawing.Point(511, 63);
            this.txtSql.Margin = new System.Windows.Forms.Padding(10);
            this.txtSql.Multiline = true;
            this.txtSql.Name = "txtSql";
            this.txtSql.ReadOnly = true;
            this.txtSql.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSql.Size = new System.Drawing.Size(433, 501);
            this.txtSql.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnCopy, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnClear, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnGenSql, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(504, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(447, 47);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // btnCopy
            // 
            this.btnCopy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Icon = FontAwesome.Sharp.IconChar.Clone;
            this.btnCopy.IconColor = System.Drawing.Color.Black;
            this.btnCopy.IconSize = 32;
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.Location = new System.Drawing.Point(400, 3);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(44, 41);
            this.btnCopy.TabIndex = 6;
            this.btnCopy.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Icon = FontAwesome.Sharp.IconChar.Trash;
            this.btnClear.IconColor = System.Drawing.Color.Black;
            this.btnClear.IconSize = 32;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(350, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(44, 41);
            this.btnClear.TabIndex = 7;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnGenSql
            // 
            this.btnGenSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGenSql.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenSql.Icon = FontAwesome.Sharp.IconChar.FileCodeO;
            this.btnGenSql.IconColor = System.Drawing.Color.Black;
            this.btnGenSql.IconSize = 32;
            this.btnGenSql.Image = ((System.Drawing.Image)(resources.GetObject("btnGenSql.Image")));
            this.btnGenSql.Location = new System.Drawing.Point(300, 3);
            this.btnGenSql.Name = "btnGenSql";
            this.btnGenSql.Size = new System.Drawing.Size(44, 41);
            this.btnGenSql.TabIndex = 8;
            this.btnGenSql.UseVisualStyleBackColor = true;
            this.btnGenSql.Click += new System.EventHandler(this.btnGenSql_Click);
            // 
            // SelectQueryBuilderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(962, 649);
            this.Controls.Add(this.tlpPrincipal);
            this.ForeColor = System.Drawing.Color.SlateGray;
            this.Name = "SelectQueryBuilderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Query Constructor";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tlpPrincipal.ResumeLayout(false);
            this.tlpPrincipal.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private MaterialSkin.Controls.MaterialFlatButton btnAddTables;
        private System.Windows.Forms.FlowLayoutPanel pnlTables;
        private System.Windows.Forms.TextBox txtSql;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private FontAwesome.Sharp.IconButton btnGenSql;
        private FontAwesome.Sharp.IconButton btnCopy;
        private FontAwesome.Sharp.IconButton btnClear;
    }
}