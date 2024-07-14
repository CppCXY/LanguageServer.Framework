using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.WorkspaceWatchedFile.Watch;

[JsonConverter(typeof(FileChangeTypeJsonConverter))]
public readonly record struct FileChangeType(int Value)
{
    /**
     * The file got created.
     */
    public static FileChangeType Created { get; } = new(1);

    /**
     * The file got changed.
     */
    public static FileChangeType Changed { get; } = new(2);

    /**
     * The file got deleted.
     */
    public static FileChangeType Deleted { get; } = new(3);
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
        writer.WriteNumberValue(value.Value);
    }
}
