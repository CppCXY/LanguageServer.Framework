using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.WorkspaceWatchedFile.Watch;

[JsonConverter(typeof(FileChangeTypeJsonConverter))]
public enum FileChangeType
{
    /**
     * The file got created.
     */
    Created = 1,

    /**
     * The file got changed.
     */
    Changed = 2,

    /**
     * The file got deleted.
     */
    Deleted = 3
}

public class FileChangeTypeJsonConverter : JsonConverter<FileChangeType>
{
    public override FileChangeType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetInt32() switch
        {
            1 => FileChangeType.Created,
            2 => FileChangeType.Changed,
            3 => FileChangeType.Deleted,
            _ => throw new JsonException()
        };
    }

    public override void Write(Utf8JsonWriter writer, FileChangeType value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue((int)value);
    }
}
