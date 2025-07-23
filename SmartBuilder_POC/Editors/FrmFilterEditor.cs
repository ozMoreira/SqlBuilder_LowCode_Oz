using SmartBuilder_POC.Helpers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartBuilder_POC.Editors
{
    public partial class FrmFilterEditor : Form
    {
        public string SelectedOperator { get; private set; }
        public string FilterValue { get; private set; }

        private const string PlaceholderIn = "Ex: 1,2,3 ou A,B,C";

        public FrmFilterEditor(string currentOperator, string currentValue)
        {
            InitializeComponent();
            cmbOperator.SelectedIndexChanged += (s, e) => AjustarCamposValor();
            this.Size = new Size(300, 140);
            cmbOperator.Items.AddRange(new OperatorFilter[] {
                new OperatorFilter("= (Igual)", "="),
                new OperatorFilter("<> (Diferente)", "<>"),
                new OperatorFilter("> (Maior que)", ">"),
                new OperatorFilter("< (Menor que)", "<"),
                new OperatorFilter(">= (Maior ou igual)", ">="),
                new OperatorFilter("<= (Menor ou igual)", "<="),
                new OperatorFilter("LIKE (Contém)", "LIKE"),
                new OperatorFilter("NOT LIKE (Não contém)", "NOT LIKE"),
                new OperatorFilter("IN (Lista de valores)", "IN"),
                new OperatorFilter("NOT IN (Não está na lista)", "NOT IN"),
                new OperatorFilter("IS NULL (Vazio)", "IS NULL"),
                new OperatorFilter("IS NOT NULL (Preenchido)", "IS NOT NULL"),
                new OperatorFilter("BETWEEN (Entre)", "BETWEEN"),
            });
            cmbOperator.SelectedIndex = 0;
            cmbOperator.SelectedItem = currentOperator ?? "=";

            this.AcceptButton = btnOk;
            this.CancelButton = btnCancel;

            if (currentOperator == "BETWEEN" && !string.IsNullOrEmpty(currentValue))
            {
                var partes = currentValue.Split(new[] { "AND" }, StringSplitOptions.None);
                txtValue.Text = partes.Length > 0 ? partes[0].Trim() : "";
                txtValue2.Text = partes.Length > 1 ? partes[1].Trim() : "";
            }
            else if (currentOperator == "IN" || currentOperator == "NOT IN")
            {
                // Mostra o placeholder se não há valor preenchido
                txtValue.Text = string.IsNullOrWhiteSpace(currentValue) ? PlaceholderIn : currentValue;
                txtValue.ForeColor = string.IsNullOrWhiteSpace(currentValue) ? Color.Gray : SystemColors.WindowText;
            }
            else
            {
                txtValue.Text = currentValue ?? "";
                txtValue.ForeColor = SystemColors.WindowText;
            }

            txtValue.GotFocus += (s, e) =>
            {
                if (txtValue.Text == PlaceholderIn)
                {
                    txtValue.Text = "";
                    txtValue.ForeColor = SystemColors.WindowText;
                }
            };
            txtValue.LostFocus += (s, e) =>
            {
                var op = cmbOperator.SelectedItem as OperatorFilter;
                if ((op?.SqlOperator == "IN" || op?.SqlOperator == "NOT IN") && string.IsNullOrWhiteSpace(txtValue.Text))
                {
                    txtValue.Text = PlaceholderIn;
                    txtValue.ForeColor = Color.Gray;
                }
            };

            // Ajusta visibilidade logo ao abrir
            AjustarCamposValor();

            btnOk.Click += (s, e) =>
            {
                if (cmbOperator.SelectedItem is OperatorFilter operador)
                {
                    this.SelectedOperator = operador.SqlOperator;
                    if (operador.SqlOperator == "BETWEEN")
                        this.FilterValue = $"{txtValue.Text} AND {txtValue2.Text}";
                    else if (operador.SqlOperator == "IN" || operador.SqlOperator == "NOT IN")
                        this.FilterValue = txtValue.Text == PlaceholderIn ? "" : txtValue.Text;
                    else if (operador.SqlOperator == "IS NULL" || operador.SqlOperator == "IS NOT NULL")
                        this.FilterValue = "";
                    else
                        this.FilterValue = txtValue.Text;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            };
        }

        private void AjustarCamposValor()
        {
            var op = cmbOperator.SelectedItem as OperatorFilter;
            if (op == null) return;

            if (op.SqlOperator == "BETWEEN")
            {
                txtValue2.Visible = true;
                lblE.Visible = true;
                txtValue.Visible = true;
                txtValue.ForeColor = SystemColors.WindowText;
            }
            else
            {
                txtValue2.Visible = false;
                lblE.Visible = false;
                txtValue.Visible = op.SqlOperator != "IS NULL" && op.SqlOperator != "IS NOT NULL";
            }

            // IS NULL e IS NOT NULL escondem o campo de valor
            if (op.SqlOperator == "IS NULL" || op.SqlOperator == "IS NOT NULL")
            {
                txtValue.Visible = false;
                txtValue2.Visible = false;
                lblE.Visible = false;
            }

            // IN e NOT IN: mostra placeholder se vazio ou placeholder antigo
            if ((op.SqlOperator == "IN" || op.SqlOperator == "NOT IN"))
            {
                if (string.IsNullOrWhiteSpace(txtValue.Text) || txtValue.Text == PlaceholderIn)
                {
                    txtValue.Text = PlaceholderIn;
                    txtValue.ForeColor = Color.Gray;
                }
            }
            else if (txtValue.Text == PlaceholderIn)
            {
                txtValue.Text = "";
                txtValue.ForeColor = SystemColors.WindowText;
            }
        }
    }
}
