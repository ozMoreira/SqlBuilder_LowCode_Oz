namespace SmartBuilder_POC.Controls
{
    partial class SelectedTableControl
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
            this.cmbTable = new System.Windows.Forms.ComboBox();
            this.clbFields = new System.Windows.Forms.CheckedListBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lblFields = new System.Windows.Forms.Label();
            this.lblTable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbTable
            // 
            this.cmbTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTable.FormattingEnabled = true;
            this.cmbTable.Location = new System.Drawing.Point(22, 44);
            this.cmbTable.Name = "cmbTable";
            this.cmbTable.Size = new System.Drawing.Size(121, 24);
            this.cmbTable.TabIndex = 0;
            // 
            // clbFields
            // 
            this.clbFields.CheckOnClick = true;
            this.clbFields.FormattingEnabled = true;
            this.clbFields.Location = new System.Drawing.Point(23, 103);
            this.clbFields.Name = "clbFields";
            this.clbFields.Size = new System.Drawing.Size(120, 276);
            this.clbFields.TabIndex = 1;
            // 
            // btnRemove
            // 
            this.btnRemove.Image = global::SmartBuilder_POC.Properties.Resources.delete;
            this.btnRemove.Location = new System.Drawing.Point(22, 402);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(120, 64);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // lblFields
            // 
            this.lblFields.AutoSize = true;
            this.lblFields.Location = new System.Drawing.Point(23, 84);
            this.lblFields.Name = "lblFields";
            this.lblFields.Size = new System.Drawing.Size(58, 16);
            this.lblFields.TabIndex = 3;
            this.lblFields.Text = "Campos";
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.Location = new System.Drawing.Point(23, 25);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(51, 16);
            this.lblTable.TabIndex = 4;
            this.lblTable.Text = "Tabela";
            // 
            // SelectedTableControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTable);
            this.Controls.Add(this.lblFields);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.clbFields);
            this.Controls.Add(this.cmbTable);
            this.Name = "SelectedTableControl";
            this.Size = new System.Drawing.Size(166, 489);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTable;
        private System.Windows.Forms.CheckedListBox clbFields;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label lblFields;
        private System.Windows.Forms.Label lblTable;
    }
}
