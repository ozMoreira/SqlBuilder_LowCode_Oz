using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartBuilder_POC.Editors
{
    public partial class FrmSqlViewer : Form
    {

        private readonly string _connectionString;

        public FrmSqlViewer(string sql, string connectionString)
        {
            InitializeComponent();
            txtSql.Text = sql;
            _connectionString = connectionString;

            btnCoppy.Click += (s, e) => CopiarSql();
            btnExecute.Click += (s, e) => ExecutarConsulta();
        }

        private void CopiarSql()
        {
            Clipboard.SetText(txtSql.Text);
            btnCoppy.Text = "Copiado!";
        }

        private void ExecutarConsulta()
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(txtSql.Text, conn))
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);
                        dgvResult.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao executar SQL:\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
    
