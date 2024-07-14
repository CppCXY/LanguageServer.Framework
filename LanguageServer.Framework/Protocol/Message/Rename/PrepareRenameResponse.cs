using System.Text.Json;
using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.Rename;

[JsonConverter(typeof(PrepareRenameResponseJsonConverter))]
public class PrepareRenameResponse
{
    public int Index { get; set; }

    public DocumentRange Range { get; set; }

    public string? Placeholder { get; set; }

    public bool? DefaultBehavior { get; set; }

    public PrepareRenameResponse(DocumentRange range)
    {
        Index = 0;
        Range = range;
    }

    public PrepareRenameResponse(DocumentRange range, string placeholder)
    {
        Index = 1;
        Range = range;
        Placeholder = placeholder;
    }

    public PrepareRenameResponse(bool defaultBehavior)
    {
        Index = 2;
        DefaultBehavior = defaultBehavior;
    }
}

public class PrepareRenameResponseJsonConverter : JsonConverter<PrepareRenameResponse>
{
    public override PrepareRenameResponse Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, PrepareRenameResponse value, JsonSerializerOptions options)
    {
        switch (value.Index)
        {
            case 0:
            {
                JsonSerializer.Serialize(writer, value.Range, options);
                break;
            }
            case 1:
            {
                writer.WriteStartObject();
                writer.WritePropertyName("range");
                JsonSerializer.Serialize(writer, value.Range, options);
                writer.WriteString("placeholder", value.Placeholder);
                writer.WriteEndObject();
                break;
            }
            case 2:
            {
                writer.WriteStartObject();
                writer.WriteBoolean("defaultBehavior", value.DefaultBehavior!.Value);
                writer.WriteEndObject();
                break;
            }
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
