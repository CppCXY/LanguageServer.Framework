using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Model.Kind;

[JsonConverter(typeof(MonikerKindJsonConverter))]
public readonly record struct MonikerKind
{
    public static readonly MonikerKind Import = new() { Kind = "import" };
    public static readonly MonikerKind Export = new() { Kind = "export" };
    public static readonly MonikerKind Local = new() { Kind = "local" };
    public required string Kind { get; init; }
}

public class MonikerKindJsonConverter : JsonConverter<MonikerKind>
{
    public override MonikerKind Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return new MonikerKind { Kind = value! };
    }

    public override void Write(Utf8JsonWriter writer, MonikerKind value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Kind);
    }
}
