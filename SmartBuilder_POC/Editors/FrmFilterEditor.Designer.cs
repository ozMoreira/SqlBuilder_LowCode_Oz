namespace SmartBuilder_POC.Editors
{
    partial class FrmFilterEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFilterEditor));
            this.cmbOperator = new System.Windows.Forms.ComboBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.txtValue2 = new System.Windows.Forms.TextBox();
            this.lblE = new System.Windows.Forms.Label();
            this.btnOk = new FontAwesome.Sharp.IconButton();
            this.btnCancel = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // cmbOperator
            // 
            this.cmbOperator.FormattingEnabled = true;
            this.cmbOperator.Location = new System.Drawing.Point(18, 20);
            this.cmbOperator.Margin = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.cmbOperator.Name = "cmbOperator";
            this.cmbOperator.Size = new System.Drawing.Size(305, 21);
            this.cmbOperator.TabIndex = 0;
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(18, 60);
            this.txtValue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(127, 20);
            this.txtValue.TabIndex = 1;
            // 
            // txtValue2
            // 
            this.txtValue2.Location = new System.Drawing.Point(196, 60);
            this.txtValue2.Margin = new System.Windows.Forms.Padding(2, 2, 10, 2);
            this.txtValue2.Name = "txtValue2";
            this.txtValue2.Size = new System.Drawing.Size(127, 20);
            this.txtValue2.TabIndex = 2;
            // 
            // lblE
            // 
            this.lblE.AutoSize = true;
            this.lblE.Location = new System.Drawing.Point(163, 64);
            this.lblE.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblE.Name = "lblE";
            this.lblE.Size = new System.Drawing.Size(14, 13);
            this.lblE.TabIndex = 3;
            this.lblE.Text = "E";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Icon = FontAwesome.Sharp.IconChar.Check;
            this.btnOk.IconColor = System.Drawing.Color.Black;
            this.btnOk.IconSize = 32;
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.Location = new System.Drawing.Point(18, 93);
            this.btnOk.Margin = new System.Windows.Forms.Padding(2, 2, 2, 10);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(146, 28);
            this.btnOk.TabIndex = 4;
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Icon = FontAwesome.Sharp.IconChar.Times;
            this.btnCancel.IconColor = System.Drawing.Color.Black;
            this.btnCancel.IconSize = 32;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(176, 93);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 10, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(146, 28);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FrmFilterEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(336, 136);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblE);
            this.Controls.Add(this.txtValue2);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.cmbOperator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimizeBox = false;
            this.Name = "FrmFilterEditor";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Filtros";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbOperator;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.TextBox txtValue2;
        private System.Windows.Forms.Label lblE;
        private FontAwesome.Sharp.IconButton btnOk;
        private FontAwesome.Sharp.IconButton btnCancel;
    }
}