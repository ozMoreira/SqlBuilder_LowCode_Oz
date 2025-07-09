using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SmartBuilder_POC.Services
{
    public static class SqlQueryBuilderService
    {
        public class TableBlock
        {
            public string TableName { get; set; }

            public List<string> SelectedFields { get; set; }

            public List<string> WhereConditions { get; set; }

            public TableBlock()
            {
                SelectedFields = new List<string>();
                WhereConditions = new List<string>();
            }
        }

        public static string GenerateSelectQuery(List<TableBlock> blocks)
        {
            if (blocks == null || blocks.Count == 0)
                return "-- Nenhuma tabela foi selecionada.";

            var aliasMap = new Dictionary<string, string>();
            char alias = 'A';

            var selectFields = new List<string>();
            var whereClauses = new List<string>();

            foreach (var block in blocks)
            {
                if (string.IsNullOrWhiteSpace(block.TableName)) continue;

                if (!aliasMap.ContainsKey(block.TableName))
                    aliasMap[block.TableName] = alias++.ToString();

                string tblAlias = aliasMap[block.TableName];

                foreach (var field in block.SelectedFields)
                    selectFields.Add(string.Format("{0}.{1}", tblAlias, field.ToUpper()));

                foreach (var condition in block.WhereConditions)
                    whereClauses.Add(string.Format("{0}.{1}", tblAlias, condition));
            }

            string fromClause = string.Join(", ", aliasMap.Select(kv => string.Format("{0} {1}", kv.Key, kv.Value)));
            string whereClause = whereClauses.Count > 0 ? "\n WHERE " + string.Join(" AND ", whereClauses) : "";

            string sql = "SELECT " + string.Join(", ", selectFields) + "\n FROM " + fromClause + whereClause;
            return sql;
        }

        internal static void ClearSqlOutput(TextBox txtSql)
        {
            txtSql.Clear();
        }
    }
}
