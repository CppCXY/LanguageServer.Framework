using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.Completion;

[JsonConverter(typeof(CompletionResponseJsonConverter))]
public class CompletionResponse
{
    public List<CompletionItem>? Items { get; set; }

    public CompletionList? List { get; set; } = null;

    public CompletionResponse(List<CompletionItem> items)
    {
        Items = items;
    }

    public CompletionResponse(CompletionList list)
    {
        List = list;
    }
}

public class CompletionResponseJsonConverter : JsonConverter<CompletionResponse>
{
    public override CompletionResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new UnreachableException();
    }

    public override void Write(Utf8JsonWriter writer, CompletionResponse value, JsonSerializerOptions options)
    {
        if (value.Items != null)
        {
            JsonSerializer.Serialize(writer, value.Items, options);
        }
        else if (value.List != null)
        {
            JsonSerializer.Serialize(writer, value.List, options);
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
