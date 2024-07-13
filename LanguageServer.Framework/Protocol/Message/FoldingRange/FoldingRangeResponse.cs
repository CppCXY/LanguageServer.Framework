using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.FoldingRange;

[JsonConverter(typeof(FoldingRangeResponseJsonConverter))]
public class FoldingRangeResponse(List<FoldingRange> foldingRanges)
{
    public List<FoldingRange> FoldingRanges { get; set; } = foldingRanges;
}

public class FoldingRangeResponseJsonConverter : JsonConverter<FoldingRangeResponse>
{
    public override FoldingRangeResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, FoldingRangeResponse value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.FoldingRanges, options);
    }
}
