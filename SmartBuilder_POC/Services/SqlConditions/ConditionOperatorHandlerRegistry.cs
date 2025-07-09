using System.Collections.Generic;

namespace SmartBuilder_POC.Services.SqlConditions
{
    public static class ConditionOperatorHandlerRegistry
    {
        public static readonly Dictionary<string, IConditionOperatorHandler> Handlers;

        static ConditionOperatorHandlerRegistry()
        {
            Handlers = new Dictionary<string, IConditionOperatorHandler>
            {
                { "=", new SimpleValueOperatorHandler("=") },
                { "<>", new SimpleValueOperatorHandler("<>") },
                { "!=", new SimpleValueOperatorHandler("!=") },
                { "<", new SimpleValueOperatorHandler("<") },
                { ">", new SimpleValueOperatorHandler(">") },
                { "<=", new SimpleValueOperatorHandler("<=") },
                { ">=", new SimpleValueOperatorHandler(">=") },
                { "LIKE", new SimpleValueOperatorHandler("LIKE") },
                { "NOT LIKE", new SimpleValueOperatorHandler("NOT LIKE") },
                { "BETWEEN", new BetweenOperatorHandler() },
                { "IN", new InOperatorHandler("IN") },
                { "NOT IN", new InOperatorHandler("NOT IN") },
                { "IS NULL", new NullOperatorHandler("IS NULL") },
                { "IS NOT NULL", new NullOperatorHandler("IS NOT NULL") }
            };
        }

        public static bool TryGetHandler(string op, out IConditionOperatorHandler handler)
        {
            return Handlers.TryGetValue(op, out handler);
        }
    }
}
