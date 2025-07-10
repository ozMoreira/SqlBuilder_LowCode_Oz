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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectedTableControl));
            this.cmbTable = new System.Windows.Forms.ComboBox();
            this.clbFields = new System.Windows.Forms.CheckedListBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lblFields = new System.Windows.Forms.Label();
            this.lblTable = new System.Windows.Forms.Label();
            this.pnlWhereConditions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddCondition = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // cmbTable
            // 
            this.cmbTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTable.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTable.FormattingEnabled = true;
            this.cmbTable.Location = new System.Drawing.Point(22, 44);
            this.cmbTable.Name = "cmbTable";
            this.cmbTable.Size = new System.Drawing.Size(402, 31);
            this.cmbTable.TabIndex = 0;
            // 
            // clbFields
            // 
            this.clbFields.CheckOnClick = true;
            this.clbFields.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.clbFields.FormattingEnabled = true;
            this.clbFields.Location = new System.Drawing.Point(23, 120);
            this.clbFields.Name = "clbFields";
            this.clbFields.Size = new System.Drawing.Size(199, 404);
            this.clbFields.TabIndex = 1;
            // 
            // btnRemove
            // 
            this.btnRemove.Image = global::SmartBuilder_POC.Properties.Resources.delete;
            this.btnRemove.Location = new System.Drawing.Point(335, 120);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(89, 55);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lblFields
            // 
            this.lblFields.AutoSize = true;
            this.lblFields.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFields.Location = new System.Drawing.Point(23, 94);
            this.lblFields.Name = "lblFields";
            this.lblFields.Size = new System.Drawing.Size(72, 23);
            this.lblFields.TabIndex = 3;
            this.lblFields.Text = "Campos";
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTable.Location = new System.Drawing.Point(23, 18);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(58, 23);
            this.lblTable.TabIndex = 4;
            this.lblTable.Text = "Tabela";
            // 
            // pnlWhereConditions
            // 
            this.pnlWhereConditions.AutoScroll = true;
            this.pnlWhereConditions.Location = new System.Drawing.Point(240, 181);
            this.pnlWhereConditions.Name = "pnlWhereConditions";
            this.pnlWhereConditions.Size = new System.Drawing.Size(184, 343);
            this.pnlWhereConditions.TabIndex = 5;
            // 
            // btnAddCondition
            // 
            this.btnAddCondition.Icon = FontAwesome.Sharp.IconChar.Filter;
            this.btnAddCondition.IconColor = System.Drawing.Color.Black;
            this.btnAddCondition.IconSize = 32;
            this.btnAddCondition.Image = ((System.Drawing.Image)(resources.GetObject("btnAddCondition.Image")));
            this.btnAddCondition.Location = new System.Drawing.Point(240, 120);
            this.btnAddCondition.Name = "btnAddCondition";
            this.btnAddCondition.Size = new System.Drawing.Size(89, 55);
            this.btnAddCondition.TabIndex = 6;
            this.btnAddCondition.UseVisualStyleBackColor = true;
            // 
            // SelectedTableControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddCondition);
            this.Controls.Add(this.pnlWhereConditions);
            this.Controls.Add(this.lblTable);
            this.Controls.Add(this.lblFields);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.clbFields);
            this.Controls.Add(this.cmbTable);
            this.Name = "SelectedTableControl";
            this.Size = new System.Drawing.Size(435, 544);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTable;
        private System.Windows.Forms.CheckedListBox clbFields;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label lblFields;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.FlowLayoutPanel pnlWhereConditions;
        private FontAwesome.Sharp.IconButton btnAddCondition;
    }
}
