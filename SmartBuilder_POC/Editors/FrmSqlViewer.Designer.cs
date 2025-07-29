namespace SmartBuilder_POC.Editors
{
    partial class FrmSqlViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSqlViewer));
            this.txtSql = new System.Windows.Forms.TextBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.btnExecute = new FontAwesome.Sharp.IconButton();
            this.btnCoppy = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSql
            // 
            this.txtSql.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSql.Location = new System.Drawing.Point(0, 0);
            this.txtSql.Multiline = true;
            this.txtSql.Name = "txtSql";
            this.txtSql.ReadOnly = true;
            this.txtSql.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSql.Size = new System.Drawing.Size(794, 162);
            this.txtSql.TabIndex = 0;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.iconButton1);
            this.pnlButtons.Controls.Add(this.btnCoppy);
            this.pnlButtons.Controls.Add(this.btnExecute);
            this.pnlButtons.Location = new System.Drawing.Point(0, 168);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(794, 47);
            this.pnlButtons.TabIndex = 1;
            // 
            // dgvResult
            // 
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Location = new System.Drawing.Point(0, 222);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.Size = new System.Drawing.Size(794, 150);
            this.dgvResult.TabIndex = 2;
            // 
            // btnExecute
            // 
            this.btnExecute.Icon = FontAwesome.Sharp.IconChar.ThList;
            this.btnExecute.IconColor = System.Drawing.Color.Black;
            this.btnExecute.IconSize = 32;
            this.btnExecute.Image = ((System.Drawing.Image)(resources.GetObject("btnExecute.Image")));
            this.btnExecute.Location = new System.Drawing.Point(3, 3);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(272, 41);
            this.btnExecute.TabIndex = 0;
            this.btnExecute.UseVisualStyleBackColor = true;
            // 
            // btnCoppy
            // 
            this.btnCoppy.Icon = FontAwesome.Sharp.IconChar.FileCodeO;
            this.btnCoppy.IconColor = System.Drawing.Color.Black;
            this.btnCoppy.IconSize = 32;
            this.btnCoppy.Image = ((System.Drawing.Image)(resources.GetObject("btnCoppy.Image")));
            this.btnCoppy.Location = new System.Drawing.Point(559, 3);
            this.btnCoppy.Name = "btnCoppy";
            this.btnCoppy.Size = new System.Drawing.Size(232, 41);
            this.btnCoppy.TabIndex = 1;
            this.btnCoppy.TabStop = false;
            this.btnCoppy.UseVisualStyleBackColor = true;
            // 
            // iconButton1
            // 
            this.iconButton1.Icon = FontAwesome.Sharp.IconChar.CommentsO;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconSize = 32;
            this.iconButton1.Image = ((System.Drawing.Image)(resources.GetObject("iconButton1.Image")));
            this.iconButton1.Location = new System.Drawing.Point(281, 3);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(272, 41);
            this.iconButton1.TabIndex = 2;
            this.iconButton1.UseVisualStyleBackColor = true;
            // 
            // FrmSqlViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 450);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.txtSql);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmSqlViewer";
            this.Text = "FrmSqlViewer";
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSql;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.DataGridView dgvResult;
        private FontAwesome.Sharp.IconButton btnCoppy;
        private FontAwesome.Sharp.IconButton btnExecute;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}