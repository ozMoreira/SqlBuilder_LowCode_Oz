using SmartBuilder_POC.Editors;
using SmartBuilder_POC.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartBuilder_POC
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string connStr = TestDbFactory.CriarBancoTeste();
            Application.Run(new FrmVisualSqlBuilder(connStr));
            //Application.Run(new SelectQueryBuilderForm(connStr));
            //Application.Run(new FrmSmartBuilder());
        }
    }
}
