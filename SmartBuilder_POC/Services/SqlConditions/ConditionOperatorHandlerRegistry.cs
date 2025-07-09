using System.Collections.Generic;

namespace SmartBuilder_POC.Services.SqlConditions
{
    public static class ConditionOperatorHandlerRegistry
    {
        public static Dictionary<string, IConditionOperatorHandler> Handlers { get; } = new()
        {
            { "=", new SimpleValueOperatorHandler("=") },
            { ">", new SimpleValueOperatorHandler(">") },
            { "<", new SimpleValueOperatorHandler("<") },
            { "<=", new SimpleValueOperatorHandler("<=") },
            { ">=", new SimpleValueOperatorHandler(">=") },
            { "<>", new SimpleValueOperatorHandler("<>") },
            { "!=", new SimpleValueOperatorHandler("!=") },
            { "LIKE", new SimpleValueOperatorHandler("LIKE") },
            { "NOT LIKE", new SimpleValueOperatorHandler("NOT LIKE") },
            { "IN", new InOperatorHandler("IN") },
            { "NOT IN", new InOperatorHandler("NOT IN") },
            { "IS NULL", new NullOperatorHandler("IS NULL") },
            { "IS NOT NULL", new NullOperatorHandler("IS NOT NULL") },
            { "BETWEEN", new BetweenOperatorHandler() }
        };
    }
}
