using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.InlineCompletion;

[JsonConverter(typeof(InlineCompletionResponseJsonConverter))]
public class InlineCompletionResponse
{
    public object Items { get; }

    public InlineCompletionResponse(List<InlineCompletionItem> items)
    {
        Items = items;
    }

    public InlineCompletionResponse(InlineCompletionList items)
    {
        Items = items;
    }

    public static implicit operator InlineCompletionResponse(List<InlineCompletionItem> items)
    {
        return new InlineCompletionResponse(items);
    }

    public static implicit operator InlineCompletionResponse(InlineCompletionList items)
    {
        return new InlineCompletionResponse(items);
    }
}

public class InlineCompletionResponseJsonConverter : JsonConverter<InlineCompletionResponse>
{
    public override InlineCompletionResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, InlineCompletionResponse value, JsonSerializerOptions options)
    {
        if (value.Items is InlineCompletionList list)
        {
            JsonSerializer.Serialize(writer, list, options);
        }
        else if (value.Items is List<InlineCompletionItem> items)
        {
            JsonSerializer.Serialize(writer, items, options);
        }
    }
}
