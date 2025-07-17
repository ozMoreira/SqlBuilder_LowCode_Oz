namespace SmartBuilder_POC.Controls
{
    partial class JoinBlockControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTipoJoin = new System.Windows.Forms.Label();
            this.cbxJoinType = new System.Windows.Forms.ComboBox();
            this.cbxTable1 = new System.Windows.Forms.ComboBox();
            this.lblTable1 = new System.Windows.Forms.Label();
            this.cbxCampo1 = new System.Windows.Forms.ComboBox();
            this.lblCampo1 = new System.Windows.Forms.Label();
            this.cbxCampo2 = new System.Windows.Forms.ComboBox();
            this.lblCampo2 = new System.Windows.Forms.Label();
            this.cbxTable2 = new System.Windows.Forms.ComboBox();
            this.lblTable2 = new System.Windows.Forms.Label();
            this.btnAddJoin = new MaterialSkin.Controls.MaterialFlatButton();
            this.SuspendLayout();
            // 
            // lblTipoJoin
            // 
            this.lblTipoJoin.AutoSize = true;
            this.lblTipoJoin.Location = new System.Drawing.Point(18, 22);
            this.lblTipoJoin.Name = "lblTipoJoin";
            this.lblTipoJoin.Size = new System.Drawing.Size(93, 16);
            this.lblTipoJoin.TabIndex = 0;
            this.lblTipoJoin.Text = "Tipo de União";
            // 
            // cbxJoinType
            // 
            this.cbxJoinType.FormattingEnabled = true;
            this.cbxJoinType.Location = new System.Drawing.Point(117, 19);
            this.cbxJoinType.Name = "cbxJoinType";
            this.cbxJoinType.Size = new System.Drawing.Size(164, 24);
            this.cbxJoinType.TabIndex = 1;
            // 
            // cbxTable1
            // 
            this.cbxTable1.FormattingEnabled = true;
            this.cbxTable1.Location = new System.Drawing.Point(92, 60);
            this.cbxTable1.Name = "cbxTable1";
            this.cbxTable1.Size = new System.Drawing.Size(189, 24);
            this.cbxTable1.TabIndex = 3;
            // 
            // lblTable1
            // 
            this.lblTable1.AutoSize = true;
            this.lblTable1.Location = new System.Drawing.Point(25, 63);
            this.lblTable1.Name = "lblTable1";
            this.lblTable1.Size = new System.Drawing.Size(61, 16);
            this.lblTable1.TabIndex = 2;
            this.lblTable1.Text = "Tabela 1";
            // 
            // cbxCampo1
            // 
            this.cbxCampo1.FormattingEnabled = true;
            this.cbxCampo1.Location = new System.Drawing.Point(375, 60);
            this.cbxCampo1.Name = "cbxCampo1";
            this.cbxCampo1.Size = new System.Drawing.Size(189, 24);
            this.cbxCampo1.TabIndex = 5;
            // 
            // lblCampo1
            // 
            this.lblCampo1.AutoSize = true;
            this.lblCampo1.Location = new System.Drawing.Point(308, 60);
            this.lblCampo1.Name = "lblCampo1";
            this.lblCampo1.Size = new System.Drawing.Size(61, 16);
            this.lblCampo1.TabIndex = 4;
            this.lblCampo1.Text = "Campo 1";
            // 
            // cbxCampo2
            // 
            this.cbxCampo2.FormattingEnabled = true;
            this.cbxCampo2.Location = new System.Drawing.Point(375, 96);
            this.cbxCampo2.Name = "cbxCampo2";
            this.cbxCampo2.Size = new System.Drawing.Size(189, 24);
            this.cbxCampo2.TabIndex = 9;
            // 
            // lblCampo2
            // 
            this.lblCampo2.AutoSize = true;
            this.lblCampo2.Location = new System.Drawing.Point(308, 102);
            this.lblCampo2.Name = "lblCampo2";
            this.lblCampo2.Size = new System.Drawing.Size(61, 16);
            this.lblCampo2.TabIndex = 8;
            this.lblCampo2.Text = "Campo 2";
            // 
            // cbxTable2
            // 
            this.cbxTable2.FormattingEnabled = true;
            this.cbxTable2.Location = new System.Drawing.Point(92, 96);
            this.cbxTable2.Name = "cbxTable2";
            this.cbxTable2.Size = new System.Drawing.Size(189, 24);
            this.cbxTable2.TabIndex = 7;
            // 
            // lblTable2
            // 
            this.lblTable2.AutoSize = true;
            this.lblTable2.Location = new System.Drawing.Point(25, 99);
            this.lblTable2.Name = "lblTable2";
            this.lblTable2.Size = new System.Drawing.Size(61, 16);
            this.lblTable2.TabIndex = 6;
            this.lblTable2.Text = "Tabela 2";
            // 
            // btnAddJoin
            // 
            this.btnAddJoin.AutoSize = true;
            this.btnAddJoin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddJoin.Depth = 0;
            this.btnAddJoin.Location = new System.Drawing.Point(245, 138);
            this.btnAddJoin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAddJoin.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddJoin.Name = "btnAddJoin";
            this.btnAddJoin.Primary = false;
            this.btnAddJoin.Size = new System.Drawing.Size(124, 36);
            this.btnAddJoin.TabIndex = 10;
            this.btnAddJoin.Text = "Une Tabelas";
            this.btnAddJoin.UseVisualStyleBackColor = true;
            this.btnAddJoin.Click += new System.EventHandler(this.btnAddJoin_Click);
            // 
            // JoinBlockControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddJoin);
            this.Controls.Add(this.cbxCampo2);
            this.Controls.Add(this.lblCampo2);
            this.Controls.Add(this.cbxTable2);
            this.Controls.Add(this.lblTable2);
            this.Controls.Add(this.cbxCampo1);
            this.Controls.Add(this.lblCampo1);
            this.Controls.Add(this.cbxTable1);
            this.Controls.Add(this.lblTable1);
            this.Controls.Add(this.cbxJoinType);
            this.Controls.Add(this.lblTipoJoin);
            this.Name = "JoinBlockControl";
            this.Size = new System.Drawing.Size(600, 189);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTipoJoin;
        private System.Windows.Forms.ComboBox cbxJoinType;
        private System.Windows.Forms.ComboBox cbxTable1;
        private System.Windows.Forms.Label lblTable1;
        private System.Windows.Forms.ComboBox cbxCampo1;
        private System.Windows.Forms.Label lblCampo1;
        private System.Windows.Forms.ComboBox cbxCampo2;
        private System.Windows.Forms.Label lblCampo2;
        private System.Windows.Forms.ComboBox cbxTable2;
        private System.Windows.Forms.Label lblTable2;
        private MaterialSkin.Controls.MaterialFlatButton btnAddJoin;
    }
}
