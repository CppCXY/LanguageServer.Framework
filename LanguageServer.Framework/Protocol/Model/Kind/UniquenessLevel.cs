using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Model.Kind;

[JsonConverter(typeof(UniquenessLevelJsonConverter))]
public readonly record struct UniquenessLevel
{
    public static readonly UniquenessLevel Document = new() { Level = "document" };
    public static readonly UniquenessLevel Project = new() { Level = "project" };
    public static readonly UniquenessLevel Group = new() { Level = "group" };
    public static readonly UniquenessLevel Scheme = new() { Level = "scheme" };
    public static readonly UniquenessLevel Global = new() { Level = "global" };
    public required string Level { get; init; }
}

public class UniquenessLevelJsonConverter : JsonConverter<UniquenessLevel>
{
    public override UniquenessLevel Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return new UniquenessLevel { Level = value! };
    }

    public override void Write(Utf8JsonWriter writer, UniquenessLevel value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Level);
    }
}
