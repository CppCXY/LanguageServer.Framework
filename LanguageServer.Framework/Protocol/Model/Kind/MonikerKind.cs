using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Model.Kind;

[JsonConverter(typeof(MonikerKindJsonConverter))]
public readonly record struct MonikerKind(string Kind)
{
    public static readonly MonikerKind Import = new("import");
    public static readonly MonikerKind Export = new("export");
    public static readonly MonikerKind Local = new("local");
    public string Kind { get; } = Kind;
}

public class MonikerKindJsonConverter : JsonConverter<MonikerKind>
{
    public override MonikerKind Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return new MonikerKind(value!);
    }

    public override void Write(Utf8JsonWriter writer, MonikerKind value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Kind);
    }
}
