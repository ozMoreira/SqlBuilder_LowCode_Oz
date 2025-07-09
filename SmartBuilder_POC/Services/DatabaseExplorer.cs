using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SmartBuilder_POC.Services
{
    public class DatabaseExplorer : IDatabaseSchemaProvider
    {
        private readonly string _connectionString;

        public DatabaseExplorer(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<string> GetTabelas()
        {
            var tabelas = new List<string>();

            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type = 'table' AND name LIKE 'TB_%'", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tabelas.Add(reader.GetString(0));
                    }
                }
            }

            return tabelas;
        }

        public List<string> GetCampos(string tabela)
        {
            var campos = new List<string>();

            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SQLiteCommand($"PRAGMA table_info({tabela})", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        campos.Add(reader["name"].ToString());
                    }
                }
            }

            return campos;
        }
    }
}