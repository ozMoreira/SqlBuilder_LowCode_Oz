using SmartBuilder_POC.Models;
using System;

namespace SmartBuilder_POC.Services.SqlConditions
{
    internal class JoinBlockHandler : IQueryPartHandler
    {
        public bool CanHandle(SqlBlock block)
            => block is JoinBlock;

        public string Build(SqlBlock block)
        {
            var join = block as JoinBlock
                       ?? throw new ArgumentException("Block inválido para JoinBlockHandler");

            // Monta o SQL de acordo com o tipo de join
            string keyword;
            switch (join.Type)
            {
                case JoinType.Inner: keyword = "INNER JOIN"; break;
                case JoinType.Left: keyword = "LEFT JOIN"; break;
                case JoinType.Right: keyword = "RIGHT JOIN"; break;
                case JoinType.Full: keyword = "FULL JOIN"; break;
                default: keyword = "JOIN"; break;
            }

            return $"{keyword} {join.RightTable} " +
                   $"ON {join.LeftTable}.{join.LeftColumn} = {join.RightTable}.{join.RightColumn}";
        }
    }
}