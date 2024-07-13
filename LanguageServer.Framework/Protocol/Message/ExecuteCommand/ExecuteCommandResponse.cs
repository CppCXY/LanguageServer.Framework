using System.Text.Json;
using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.ExecuteCommand;

[JsonConverter(typeof(ExecuteCommandResponseJsonConverter))]
public class ExecuteCommandResponse(LSPAny? result)
{
    public LSPAny? Result { get; set; } = result;
}

public class ExecuteCommandResponseJsonConverter : JsonConverter<ExecuteCommandResponse>
{
    public override ExecuteCommandResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var result = JsonSerializer.Deserialize<LSPAny>(ref reader, options);
        return new ExecuteCommandResponse(result);
    }

    public override void Write(Utf8JsonWriter writer, ExecuteCommandResponse value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Result, options);
    }
}
