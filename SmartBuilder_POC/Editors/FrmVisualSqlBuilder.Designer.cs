namespace SmartBuilder_POC.Forms
{
    partial class FrmVisualSqlBuilder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVisualSqlBuilder));
            this.pnlPallete = new System.Windows.Forms.Panel();
            this.pnlCanvas = new System.Windows.Forms.Panel();
            this.btnGenerateSql = new MaterialSkin.Controls.MaterialFlatButton();
            this.cmbTabelas = new System.Windows.Forms.ComboBox();
            this.lblTabelas = new MaterialSkin.Controls.MaterialLabel();
            this.lstCampos = new System.Windows.Forms.ListBox();
            this.btnLimparCanvas = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // pnlPallete
            // 
            this.pnlPallete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPallete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPallete.Location = new System.Drawing.Point(9, 281);
            this.pnlPallete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlPallete.Name = "pnlPallete";
            this.pnlPallete.Size = new System.Drawing.Size(323, 318);
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
            this.pnlCanvas.Location = new System.Drawing.Point(336, 90);
            this.pnlCanvas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlCanvas.Name = "pnlCanvas";
            this.pnlCanvas.Size = new System.Drawing.Size(760, 509);
            this.pnlCanvas.TabIndex = 1;
            // 
            // btnGenerateSql
            // 
            this.btnGenerateSql.AutoSize = true;
            this.btnGenerateSql.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGenerateSql.Depth = 0;
            this.btnGenerateSql.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnGenerateSql.Location = new System.Drawing.Point(0, 600);
            this.btnGenerateSql.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnGenerateSql.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGenerateSql.Name = "btnGenerateSql";
            this.btnGenerateSql.Primary = false;
            this.btnGenerateSql.Size = new System.Drawing.Size(1096, 36);
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
            this.cmbTabelas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTabelas.FormattingEnabled = true;
            this.cmbTabelas.IntegralHeight = false;
            this.cmbTabelas.ItemHeight = 20;
            this.cmbTabelas.Location = new System.Drawing.Point(9, 102);
            this.cmbTabelas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbTabelas.Name = "cmbTabelas";
            this.cmbTabelas.Size = new System.Drawing.Size(324, 28);
            this.cmbTabelas.TabIndex = 3;
            this.cmbTabelas.SelectedIndexChanged += new System.EventHandler(this.cmbTabelas_SelectedIndexChanged);
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
            this.lblTabelas.Location = new System.Drawing.Point(11, 71);
            this.lblTabelas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTabelas.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTabelas.Name = "lblTabelas";
            this.lblTabelas.Size = new System.Drawing.Size(144, 19);
            this.lblTabelas.TabIndex = 4;
            this.lblTabelas.Text = "Tabelas Disponíveis";
            // 
            // lstCampos
            // 
            this.lstCampos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCampos.FormattingEnabled = true;
            this.lstCampos.ItemHeight = 20;
            this.lstCampos.Location = new System.Drawing.Point(9, 132);
            this.lstCampos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstCampos.Name = "lstCampos";
            this.lstCampos.Size = new System.Drawing.Size(324, 144);
            this.lstCampos.TabIndex = 5;
            this.lstCampos.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstCampos_MouseDown);
            // 
            // btnLimparCanvas
            // 
            this.btnLimparCanvas.Icon = FontAwesome.Sharp.IconChar.Magic;
            this.btnLimparCanvas.IconColor = System.Drawing.Color.Black;
            this.btnLimparCanvas.IconSize = 32;
            this.btnLimparCanvas.Image = ((System.Drawing.Image)(resources.GetObject("btnLimparCanvas.Image")));
            this.btnLimparCanvas.Location = new System.Drawing.Point(1048, 64);
            this.btnLimparCanvas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLimparCanvas.Name = "btnLimparCanvas";
            this.btnLimparCanvas.Size = new System.Drawing.Size(39, 34);
            this.btnLimparCanvas.TabIndex = 6;
            this.btnLimparCanvas.UseVisualStyleBackColor = true;
            // 
            // FrmVisualSqlBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 636);
            this.Controls.Add(this.btnLimparCanvas);
            this.Controls.Add(this.lstCampos);
            this.Controls.Add(this.lblTabelas);
            this.Controls.Add(this.cmbTabelas);
            this.Controls.Add(this.btnGenerateSql);
            this.Controls.Add(this.pnlCanvas);
            this.Controls.Add(this.pnlPallete);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmVisualSqlBuilder";
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
        private System.Windows.Forms.ListBox lstCampos;
        private FontAwesome.Sharp.IconButton btnLimparCanvas;
    }
}