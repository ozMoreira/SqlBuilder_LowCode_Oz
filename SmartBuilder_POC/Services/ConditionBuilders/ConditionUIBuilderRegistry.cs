using SmartBuilder_POC.Services.ConditionBuilders;
using System.Collections.Generic;

public static class ConditionUIBuilderRegistry
{
    private static readonly Dictionary<string, IConditionUIBuilder> _builders = new Dictionary<string, IConditionUIBuilder>
    {
        { "=", new SimpleValueConditionUIBuilder() },
        { "<>", new SimpleValueConditionUIBuilder() },
        { ">", new SimpleValueConditionUIBuilder() },
        { "<", new SimpleValueConditionUIBuilder() },
        { ">=", new SimpleValueConditionUIBuilder() },
        { "<=", new SimpleValueConditionUIBuilder() },
        { "LIKE", new LikeConditionUIBuilder() },
        { "NOT LIKE", new LikeConditionUIBuilder() },
        { "BETWEEN", new BetweenConditionUIBuilder() },
        { "IN", new InConditionUIBuilder() },
        { "NOT IN", new InConditionUIBuilder() },
        { "IS NULL", new NullConditionUIBuilder() },
        { "IS NOT NULL", new NullConditionUIBuilder() }
    };

    public static IConditionUIBuilder GetBuilder(string op)
    {
        return _builders.TryGetValue(op, out var builder)
            ? builder
            : new SimpleValueConditionUIBuilder(); // fallback
    }

    public static string[] GetSupportedOperators()
    {
        return new List<string>(_builders.Keys).ToArray();
    }
}
