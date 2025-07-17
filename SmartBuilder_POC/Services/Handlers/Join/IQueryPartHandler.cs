using SmartBuilder_POC.Models;

namespace SmartBuilder_POC.Services.SqlConditions
{
    public interface IQueryPartHandler
    public interface IQueryPartHandler
    {
        /// <summary>
        /// Informa se este handler sabe gerar SQL para o bloco recebido.
        /// </summary>
        bool CanHandle(SqlBlock block);

        /// <summary>
        /// Retorna o trecho de SQL correspondente ao bloco recebido.
        /// </summary>
        string Build(SqlBlock block);
    }
}