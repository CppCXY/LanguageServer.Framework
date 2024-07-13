using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.InlineValue;

[JsonConverter(typeof(InlineValueJsonConverter))]
public class InlineValue
{
    public object? Value { get; set; }

    public InlineValue(InlineValueText text)
    {
        Value = text;
    }

    public InlineValue(InlineValueVariableLookup lookup)
    {
        Value = lookup;
    }

    public InlineValue(InlineValueEvaluatableExpression expression)
    {
        Value = expression;
    }

    public static implicit operator InlineValue(InlineValueText text)
    {
        return new InlineValue(text);
    }

    public static implicit operator InlineValue(InlineValueVariableLookup lookup)
    {
        return new InlineValue(lookup);
    }

    public static implicit operator InlineValue(InlineValueEvaluatableExpression expression)
    {
        return new InlineValue(expression);
    }
}

public class InlineValueJsonConverter : JsonConverter<InlineValue>
{
    public override InlineValue Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, InlineValue value, JsonSerializerOptions options)
    {
        if (value.Value is InlineValueText text)
        {
            JsonSerializer.Serialize(writer, text, options);
        }
        else if (value.Value is InlineValueVariableLookup lookup)
        {
            JsonSerializer.Serialize(writer, lookup, options);
        }
        else if (value.Value is InlineValueEvaluatableExpression expression)
        {
            JsonSerializer.Serialize(writer, expression, options);
        }
        else
        {
            throw new JsonException();
        }
    }
}
