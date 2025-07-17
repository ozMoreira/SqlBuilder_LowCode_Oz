using SmartBuilder_POC.Services.SqlConditions;
using System.Collections.Generic;

namespace SmartBuilder_POC.Services.Handlers.Registry
{
    public static class QueryPartHandlerRegistry
    {
        private static readonly List<IQueryPartHandler> _handlers = new List<IQueryPartHandler>();
        /// <summary>
        /// Registra um novo handler na lista.
        /// </summary>
        public static void Register(IQueryPartHandler handler)
            => _handlers.Add(handler);

        /// <summary>
        /// Retorna todos os handlers registrados.
        /// </summary>
        public static IEnumerable<IQueryPartHandler> Handlers
            => _handlers;
    }
}