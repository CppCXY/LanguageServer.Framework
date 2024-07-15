using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Model;

[JsonConverter(typeof(DocumentUriConverter))]
public record struct DocumentUri(Uri Uri)
{
    public Uri Uri { get; } = Uri;

    public string UnescapeUri => Uri.UnescapeDataString(Uri.AbsoluteUri);

    public string FileSystemPath
    {
        get
        {
            var filePath = Uri.UnescapeDataString(Uri.AbsolutePath);
            if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows))
            {
                if (filePath.StartsWith("/"))
                {
                    filePath = filePath.TrimStart('/');
                }
                filePath = filePath.Replace("/", "\\");
            }

            return filePath;
        }
    }

    public static implicit operator DocumentUri(Uri uri) => new DocumentUri(uri);

    public static implicit operator DocumentUri(string uri) => new DocumentUri(new Uri(uri));
}

public class DocumentUriConverter : JsonConverter<DocumentUri>
{
    public override DocumentUri Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var uri = reader.GetString() ?? string.Empty;
        return new DocumentUri(new Uri(uri));
    }

    public override void Write(Utf8JsonWriter writer, DocumentUri value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Uri.ToString());
    }

    public override void WriteAsPropertyName(Utf8JsonWriter writer, DocumentUri value, JsonSerializerOptions options)
    {
        writer.WritePropertyName(value.Uri.ToString());
    }

    public override DocumentUri ReadAsPropertyName(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var uri = reader.GetString() ?? string.Empty;
        return new DocumentUri(new Uri(uri));
    }
}
