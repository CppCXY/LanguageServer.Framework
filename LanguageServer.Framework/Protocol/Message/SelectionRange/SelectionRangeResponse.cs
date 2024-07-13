using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.SelectionRange;

[JsonConverter(typeof(SelectionRangeResponseJsonConverter))]
public class SelectionRangeResponse(List<SelectionRange> ranges)
{
    public List<SelectionRange> Ranges { get; set; } = ranges;
}

public class SelectionRangeResponseJsonConverter : JsonConverter<SelectionRangeResponse>
{
    public override SelectionRangeResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new UnreachableException();
    }

    public override void Write(Utf8JsonWriter writer, SelectionRangeResponse value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Ranges, options);
    }
}
