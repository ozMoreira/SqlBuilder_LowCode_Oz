namespace SmartBuilder_POC.Editors
{
    partial class FrmJoinEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmJoinEditor));
            this.lblTable1 = new System.Windows.Forms.Label();
            this.lblTableName1 = new System.Windows.Forms.Label();
            this.lblOriginField = new System.Windows.Forms.Label();
            this.lblField1 = new System.Windows.Forms.Label();
            this.cmbTargetTable = new System.Windows.Forms.ComboBox();
            this.lblTable2 = new System.Windows.Forms.Label();
            this.cmbTargetField = new System.Windows.Forms.ComboBox();
            this.lblTargetField = new System.Windows.Forms.Label();
            this.lblJoynType = new System.Windows.Forms.Label();
            this.cmbJoinType = new System.Windows.Forms.ComboBox();
            this.btnCancel = new FontAwesome.Sharp.IconButton();
            this.btnOk = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // lblTable1
            // 
            this.lblTable1.AutoSize = true;
            this.lblTable1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTable1.Location = new System.Drawing.Point(13, 13);
            this.lblTable1.Name = "lblTable1";
            this.lblTable1.Size = new System.Drawing.Size(107, 13);
            this.lblTable1.TabIndex = 0;
            this.lblTable1.Text = "Tabela de Origem";
            // 
            // lblTableName1
            // 
            this.lblTableName1.AutoSize = true;
            this.lblTableName1.Location = new System.Drawing.Point(13, 37);
            this.lblTableName1.Name = "lblTableName1";
            this.lblTableName1.Size = new System.Drawing.Size(81, 13);
            this.lblTableName1.TabIndex = 1;
            this.lblTableName1.Text = "Recebe Origem";
            // 
            // lblOriginField
            // 
            this.lblOriginField.AutoSize = true;
            this.lblOriginField.Location = new System.Drawing.Point(13, 98);
            this.lblOriginField.Name = "lblOriginField";
            this.lblOriginField.Size = new System.Drawing.Size(81, 13);
            this.lblOriginField.TabIndex = 3;
            this.lblOriginField.Text = "Recebe Campo";
            // 
            // lblField1
            // 
            this.lblField1.AutoSize = true;
            this.lblField1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblField1.Location = new System.Drawing.Point(13, 74);
            this.lblField1.Name = "lblField1";
            this.lblField1.Size = new System.Drawing.Size(106, 13);
            this.lblField1.TabIndex = 2;
            this.lblField1.Text = "Campo de Origem";
            // 
            // cmbTargetTable
            // 
            this.cmbTargetTable.FormattingEnabled = true;
            this.cmbTargetTable.Location = new System.Drawing.Point(166, 29);
            this.cmbTargetTable.Name = "cmbTargetTable";
            this.cmbTargetTable.Size = new System.Drawing.Size(121, 21);
            this.cmbTargetTable.TabIndex = 4;
            // 
            // lblTable2
            // 
            this.lblTable2.AutoSize = true;
            this.lblTable2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTable2.Location = new System.Drawing.Point(163, 13);
            this.lblTable2.Name = "lblTable2";
            this.lblTable2.Size = new System.Drawing.Size(111, 13);
            this.lblTable2.TabIndex = 5;
            this.lblTable2.Text = "Tabela de Destino";
            // 
            // cmbTargetField
            // 
            this.cmbTargetField.FormattingEnabled = true;
            this.cmbTargetField.Location = new System.Drawing.Point(166, 95);
            this.cmbTargetField.Name = "cmbTargetField";
            this.cmbTargetField.Size = new System.Drawing.Size(121, 21);
            this.cmbTargetField.TabIndex = 6;
            // 
            // lblTargetField
            // 
            this.lblTargetField.AutoSize = true;
            this.lblTargetField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTargetField.Location = new System.Drawing.Point(163, 74);
            this.lblTargetField.Name = "lblTargetField";
            this.lblTargetField.Size = new System.Drawing.Size(110, 13);
            this.lblTargetField.TabIndex = 7;
            this.lblTargetField.Text = "Campo de Destino";
            // 
            // lblJoynType
            // 
            this.lblJoynType.AutoSize = true;
            this.lblJoynType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJoynType.Location = new System.Drawing.Point(13, 147);
            this.lblJoynType.Name = "lblJoynType";
            this.lblJoynType.Size = new System.Drawing.Size(154, 13);
            this.lblJoynType.TabIndex = 9;
            this.lblJoynType.Text = "Tipo de União de Tabelas";
            // 
            // cmbJoinType
            // 
            this.cmbJoinType.FormattingEnabled = true;
            this.cmbJoinType.Location = new System.Drawing.Point(16, 173);
            this.cmbJoinType.Name = "cmbJoinType";
            this.cmbJoinType.Size = new System.Drawing.Size(271, 21);
            this.cmbJoinType.TabIndex = 8;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Icon = FontAwesome.Sharp.IconChar.Times;
            this.btnCancel.IconColor = System.Drawing.Color.Black;
            this.btnCancel.IconSize = 32;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(158, 211);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 10, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(129, 36);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Icon = FontAwesome.Sharp.IconChar.Check;
            this.btnOk.IconColor = System.Drawing.Color.Black;
            this.btnOk.IconSize = 32;
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.Location = new System.Drawing.Point(16, 211);
            this.btnOk.Margin = new System.Windows.Forms.Padding(2, 2, 2, 10);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(130, 36);
            this.btnOk.TabIndex = 10;
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // FrmJoinEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 254);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblJoynType);
            this.Controls.Add(this.cmbJoinType);
            this.Controls.Add(this.lblTargetField);
            this.Controls.Add(this.cmbTargetField);
            this.Controls.Add(this.lblTable2);
            this.Controls.Add(this.cmbTargetTable);
            this.Controls.Add(this.lblOriginField);
            this.Controls.Add(this.lblField1);
            this.Controls.Add(this.lblTableName1);
            this.Controls.Add(this.lblTable1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmJoinEditor";
            this.Text = "União de Tabelas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTable1;
        private System.Windows.Forms.Label lblTableName1;
        private System.Windows.Forms.Label lblOriginField;
        private System.Windows.Forms.Label lblField1;
        private System.Windows.Forms.ComboBox cmbTargetTable;
        private System.Windows.Forms.Label lblTable2;
        private System.Windows.Forms.ComboBox cmbTargetField;
        private System.Windows.Forms.Label lblTargetField;
        private System.Windows.Forms.Label lblJoynType;
        private System.Windows.Forms.ComboBox cmbJoinType;
        private FontAwesome.Sharp.IconButton btnCancel;
        private FontAwesome.Sharp.IconButton btnOk;
    }
}