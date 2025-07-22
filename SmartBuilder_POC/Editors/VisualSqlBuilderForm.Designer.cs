namespace SmartBuilder_POC.Forms
{
    partial class VisualSqlBuilderForm
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
            this.pnlPallete = new System.Windows.Forms.Panel();
            this.pnlCanvas = new System.Windows.Forms.Panel();
            this.btnGenerateSql = new MaterialSkin.Controls.MaterialFlatButton();
            this.cmbTabelas = new System.Windows.Forms.ComboBox();
            this.lblTabelas = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // pnlPallete
            // 
            this.pnlPallete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPallete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPallete.Location = new System.Drawing.Point(0, 141);
            this.pnlPallete.Name = "pnlPallete";
            this.pnlPallete.Size = new System.Drawing.Size(264, 451);
            this.pnlPallete.TabIndex = 0;
            this.pnlPallete.DragDrop += new System.Windows.Forms.DragEventHandler(this.PnlCanvas_DragDrop);
            this.pnlPallete.DragEnter += new System.Windows.Forms.DragEventHandler(this.PnlCanvas_DragEnter);
            this.pnlPallete.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlPallete_MouseDown);
            // 
            // pnlCanvas
            // 
            this.pnlCanvas.AllowDrop = true;
            this.pnlCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCanvas.Location = new System.Drawing.Point(270, 84);
            this.pnlCanvas.Name = "pnlCanvas";
            this.pnlCanvas.Size = new System.Drawing.Size(993, 508);
            this.pnlCanvas.TabIndex = 1;
            // 
            // btnGenerateSql
            // 
            this.btnGenerateSql.AutoSize = true;
            this.btnGenerateSql.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGenerateSql.Depth = 0;
            this.btnGenerateSql.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnGenerateSql.Location = new System.Drawing.Point(0, 601);
            this.btnGenerateSql.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnGenerateSql.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGenerateSql.Name = "btnGenerateSql";
            this.btnGenerateSql.Primary = false;
            this.btnGenerateSql.Size = new System.Drawing.Size(1263, 36);
            this.btnGenerateSql.TabIndex = 2;
            this.btnGenerateSql.Text = "GERAR SQL";
            this.btnGenerateSql.UseVisualStyleBackColor = true;
            this.btnGenerateSql.Click += new System.EventHandler(this.BtnGenerateSql_Click);
            // 
            // cmbTabelas
            // 
            this.cmbTabelas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTabelas.CausesValidation = false;
            this.cmbTabelas.FormattingEnabled = true;
            this.cmbTabelas.IntegralHeight = false;
            this.cmbTabelas.ItemHeight = 16;
            this.cmbTabelas.Location = new System.Drawing.Point(12, 111);
            this.cmbTabelas.Name = "cmbTabelas";
            this.cmbTabelas.Size = new System.Drawing.Size(231, 24);
            this.cmbTabelas.TabIndex = 3;
            // 
            // lblTabelas
            // 
            this.lblTabelas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTabelas.AutoSize = true;
            this.lblTabelas.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTabelas.Depth = 0;
            this.lblTabelas.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTabelas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTabelas.Location = new System.Drawing.Point(34, 84);
            this.lblTabelas.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTabelas.Name = "lblTabelas";
            this.lblTabelas.Size = new System.Drawing.Size(191, 24);
            this.lblTabelas.TabIndex = 4;
            this.lblTabelas.Text = "Tabelas Disponpíveis";
            // 
            // VisualSqlBuilderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 637);
            this.Controls.Add(this.lblTabelas);
            this.Controls.Add(this.cmbTabelas);
            this.Controls.Add(this.btnGenerateSql);
            this.Controls.Add(this.pnlCanvas);
            this.Controls.Add(this.pnlPallete);
            this.Name = "VisualSqlBuilderForm";
            this.Text = "VisualSqlBuilderForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlPallete;
        private System.Windows.Forms.Panel pnlCanvas;
        private MaterialSkin.Controls.MaterialFlatButton btnGenerateSql;
        private System.Windows.Forms.ComboBox cmbTabelas;
        private MaterialSkin.Controls.MaterialLabel lblTabelas;
    }
}