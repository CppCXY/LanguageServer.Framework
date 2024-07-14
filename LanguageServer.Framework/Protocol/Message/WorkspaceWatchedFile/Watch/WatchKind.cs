using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.WorkspaceWatchedFile.Watch;

[Flags, JsonConverter(typeof(WatchKindConverter))]
public enum WatchKind
{
    /**
     * Interested in create events.
     */
    Create = 1,

    /**
     * Interested in change events.
     */
    Change = 2,

    /**
     * Interested in delete events.
     */
    Delete = 4
}

public class WatchKindConverter : JsonConverter<WatchKind>
{
    public override WatchKind Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.Number)
        {
            throw new JsonException();
        }

        return (WatchKind)reader.GetInt32();
    }

    public override void Write(Utf8JsonWriter writer, WatchKind value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue((int)value);
    }
}
