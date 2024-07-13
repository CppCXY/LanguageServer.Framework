using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.SemanticToken;

[JsonConverter(typeof(SemanticTokensDeltaResponseJsonConverter))]
public class SemanticTokensDeltaResponse
{
    public SemanticTokens? SemanticTokens { get; set; }

    public SemanticTokensDelta? SemanticTokensDelta { get; set; }

    public SemanticTokensDeltaResponse(SemanticTokens? semanticTokens)
    {
        SemanticTokens = semanticTokens;
    }

    public SemanticTokensDeltaResponse(SemanticTokensDelta? semanticTokensDelta)
    {
        SemanticTokensDelta = semanticTokensDelta;
    }

    public static implicit operator SemanticTokensDeltaResponse(SemanticTokens semanticTokens)
    {
        return new SemanticTokensDeltaResponse(semanticTokens);
    }

    public static implicit operator SemanticTokensDeltaResponse(SemanticTokensDelta semanticTokensDelta)
    {
        return new SemanticTokensDeltaResponse(semanticTokensDelta);
    }
}

public class SemanticTokensDeltaResponseJsonConverter : JsonConverter<SemanticTokensDeltaResponse>
{
    public override SemanticTokensDeltaResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, SemanticTokensDeltaResponse value, JsonSerializerOptions options)
    {
        if (value.SemanticTokens != null)
        {
            JsonSerializer.Serialize(writer, value.SemanticTokens, options);
        }
        else if (value.SemanticTokensDelta != null)
        {
            JsonSerializer.Serialize(writer, value.SemanticTokensDelta, options);
        }
    }
}
