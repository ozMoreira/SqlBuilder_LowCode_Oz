using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
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
            ExecutarConsulta();
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
                using (var conn = new SQLiteConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new SQLiteCommand(txtSql.Text, conn))
                    {
                        using (var da = new SQLiteDataAdapter(cmd))
                        {
                            var dt = new DataTable();
                            da.Fill(dt);
                            dgvResult.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao executar SQL:\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
    
