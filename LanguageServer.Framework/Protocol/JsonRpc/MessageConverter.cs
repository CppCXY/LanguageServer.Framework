using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.JsonRpc;

public class MessageConverter : JsonConverter<Message>
{
    public override Message Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDoc = JsonDocument.ParseValue(ref reader);
        var root = jsonDoc.RootElement;
        if (root.TryGetProperty("method", out var methodElement) && methodElement.GetString() is { } method)
        {
            JsonDocument? paramDocument = null;
            if (root.TryGetProperty("params", out var param))
            {
                paramDocument = JsonDocument.Parse(param.GetRawText());
            }

            if (root.TryGetProperty("id", out var id))
            {
                if (id.ValueKind == JsonValueKind.Number)
                {
                    return new RequestMessage(id.GetInt32(), method, paramDocument);
                }
                else if (id.ValueKind == JsonValueKind.String)
                {
                    return new RequestMessage(id.GetString()!, method, paramDocument);
                }
            }
            else
            {
                return new NotificationMessage(method, paramDocument);
            }
        }
        else if (root.TryGetProperty("id", out var id))
        {
            JsonDocument? resultDocument = null;
            if (root.TryGetProperty("result", out var result))
            {
                resultDocument = JsonDocument.Parse(result.GetRawText());
            }

            ResponseError? error = null;
            if (root.TryGetProperty("error", out var errorElement))
            {
                error = JsonSerializer.Deserialize<ResponseError>(errorElement.GetRawText());
            }

            if (id.ValueKind == JsonValueKind.Number)
            {
                return new ResponseMessage(id.GetInt32(), resultDocument, error);
            }
            else if (id.ValueKind == JsonValueKind.String)
            {
                return new ResponseMessage(id.GetString()!, resultDocument, error);
            }
        }

        throw new JsonException("Invalid JSON-RPC message");
    }

    public override void Write(Utf8JsonWriter writer, Message value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }
}
