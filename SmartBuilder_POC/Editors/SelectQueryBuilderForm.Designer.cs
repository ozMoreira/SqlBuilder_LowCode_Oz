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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnGenSql = new System.Windows.Forms.Button();
            this.btnAddTable = new System.Windows.Forms.Button();
            this.txtSql = new System.Windows.Forms.TextBox();
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTables = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tlpPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnAddTable, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnGenSql, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(506, 71);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // btnGenSql
            // 
            this.btnGenSql.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(46)))), ((int)(((byte)(69)))));
            this.btnGenSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGenSql.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnGenSql.ForeColor = System.Drawing.Color.White;
            this.btnGenSql.Location = new System.Drawing.Point(268, 10);
            this.btnGenSql.Margin = new System.Windows.Forms.Padding(15, 10, 10, 10);
            this.btnGenSql.Name = "btnGenSql";
            this.btnGenSql.Size = new System.Drawing.Size(228, 51);
            this.btnGenSql.TabIndex = 2;
            this.btnGenSql.Text = "Gerar Sql";
            this.btnGenSql.UseVisualStyleBackColor = false;
            this.btnGenSql.Click += new System.EventHandler(this.btnGenSql_Click);
            // 
            // btnAddTable
            // 
            this.btnAddTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(46)))), ((int)(((byte)(69)))));
            this.btnAddTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnAddTable.ForeColor = System.Drawing.Color.White;
            this.btnAddTable.Location = new System.Drawing.Point(10, 10);
            this.btnAddTable.Margin = new System.Windows.Forms.Padding(10, 10, 15, 10);
            this.btnAddTable.Name = "btnAddTable";
            this.btnAddTable.Size = new System.Drawing.Size(228, 51);
            this.btnAddTable.TabIndex = 1;
            this.btnAddTable.Text = "+ Adicionar Tabela";
            this.btnAddTable.UseVisualStyleBackColor = false;
            this.btnAddTable.Click += new System.EventHandler(this.btnAddTable_Click);
            // 
            // txtSql
            // 
            this.txtSql.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSql.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.txtSql.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSql.Location = new System.Drawing.Point(10, 616);
            this.txtSql.Margin = new System.Windows.Forms.Padding(10);
            this.txtSql.Multiline = true;
            this.txtSql.Name = "txtSql";
            this.txtSql.ReadOnly = true;
            this.txtSql.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSql.Size = new System.Drawing.Size(492, 85);
            this.txtSql.TabIndex = 3;
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.tlpPrincipal.ColumnCount = 1;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Controls.Add(this.pnlTables, 0, 1);
            this.tlpPrincipal.Controls.Add(this.txtSql, 0, 1);
            this.tlpPrincipal.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tlpPrincipal.ForeColor = System.Drawing.Color.Navy;
            this.tlpPrincipal.Location = new System.Drawing.Point(7, 8);
            this.tlpPrincipal.Margin = new System.Windows.Forms.Padding(10);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 2;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 529F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Size = new System.Drawing.Size(512, 711);
            this.tlpPrincipal.TabIndex = 5;
            // 
            // pnlTables
            // 
            this.pnlTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTables.AutoScroll = true;
            this.pnlTables.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.pnlTables.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTables.Location = new System.Drawing.Point(10, 87);
            this.pnlTables.Margin = new System.Windows.Forms.Padding(10);
            this.pnlTables.Name = "pnlTables";
            this.pnlTables.Size = new System.Drawing.Size(492, 509);
            this.pnlTables.TabIndex = 5;
            this.pnlTables.WrapContents = false;
            // 
            // SelectQueryBuilderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(527, 729);
            this.Controls.Add(this.tlpPrincipal);
            this.ForeColor = System.Drawing.Color.SlateGray;
            this.Name = "SelectQueryBuilderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Query Constructor";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tlpPrincipal.ResumeLayout(false);
            this.tlpPrincipal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnAddTable;
        private System.Windows.Forms.Button btnGenSql;
        private System.Windows.Forms.TextBox txtSql;
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.FlowLayoutPanel pnlTables;
    }
}