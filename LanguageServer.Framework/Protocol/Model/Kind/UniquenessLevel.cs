using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Model.Kind;

[JsonConverter(typeof(UniquenessLevelJsonConverter))]
public readonly record struct UniquenessLevel(string Level)
{
    public static readonly UniquenessLevel Document = new("document");
    public static readonly UniquenessLevel Project = new("project");
    public static readonly UniquenessLevel Group = new("group");
    public static readonly UniquenessLevel Scheme = new("scheme");
    public static readonly UniquenessLevel Global = new("global");
    public string Level { get; } = Level;
}

public class UniquenessLevelJsonConverter : JsonConverter<UniquenessLevel>
{
    public override UniquenessLevel Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return new UniquenessLevel(value!);
    }

    public override void Write(Utf8JsonWriter writer, UniquenessLevel value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Level);
    }
}
