using System.Collections.Generic;

namespace SmartBuilder_POC.Services
{
    // Abstração para obter listas de tabelas e campos
    public interface IDatabaseSchemaProvider
    {
        List<string> GetTabelas();
        List<string> GetCampos(string tabela);
    }
}
