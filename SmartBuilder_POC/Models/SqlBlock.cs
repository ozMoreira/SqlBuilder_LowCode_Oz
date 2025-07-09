using System.Collections.Generic;

namespace SmartBuilder_POC.Models
{
    public class SqlBlock
    {
        public string Tipo { get; set; }           // "SELECT", "IF"…
        public string Conteudo { get; set; }       // Ex. "SELECT * FROM Clientes"
        public List<SqlBlock> Filhos { get; set; } = new List<SqlBlock>();
    }
}
