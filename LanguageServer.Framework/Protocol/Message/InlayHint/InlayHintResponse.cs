using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.InlayHint;

[JsonConverter(typeof(InlayHintResponseJsonConverter))]
public class InlayHintResponse(List<InlayHint> inlayHints)
{
    public List<InlayHint> InlayHints { get; set; } = inlayHints;
}

public class InlayHintResponseJsonConverter : JsonConverter<InlayHintResponse>
{
    public override InlayHintResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, InlayHintResponse value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.InlayHints, options);
    }
}
