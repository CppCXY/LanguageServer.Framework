using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentColor;

[JsonConverter(typeof(ColorPresentationResponseJsonConverter))]
public class ColorPresentationResponse(List<ColorPresentation> presentations)
{
    public List<ColorPresentation> Presentations { get; set; } = presentations;
}

public class ColorPresentationResponseJsonConverter : JsonConverter<ColorPresentationResponse>
{
    public override ColorPresentationResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new UnreachableException();
    }

    public override void Write(Utf8JsonWriter writer, ColorPresentationResponse value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Presentations, options);
    }
}
