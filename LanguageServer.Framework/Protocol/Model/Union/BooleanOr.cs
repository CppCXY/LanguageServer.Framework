using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Model.Union;

public class BooleanOr<T>
{
    public T? Value { get; } = default;

    public bool BoolValue { get; } = false;

    public bool IsValue { get; }

    public BooleanOr(T value)
    {
        Value = value;
        IsValue = true;
    }

    public BooleanOr(bool value)
    {
        Value = default!;
        IsValue = false;
        BoolValue = value;
    }

    public static implicit operator BooleanOr<T>(T value) => new(value);

    public static implicit operator BooleanOr<T>(bool value) => new(value);
}

public class BooleanOrConverter<T> : JsonConverter<BooleanOr<T>>
{
    public override BooleanOr<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.TokenType switch
        {
            JsonTokenType.True => new BooleanOr<T>(true),
            JsonTokenType.False => new BooleanOr<T>(false),
            _ => new BooleanOr<T>(JsonSerializer.Deserialize<T>(ref reader, options)!)
        };
    }

    public override void Write(Utf8JsonWriter writer, BooleanOr<T> value, JsonSerializerOptions options)
    {
        if (value.IsValue)
        {
            JsonSerializer.Serialize(writer, value.Value, options);
        }
        else
        {
            writer.WriteBooleanValue(value.BoolValue);
        }
    }
}
