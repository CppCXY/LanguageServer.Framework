using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;
using EmmyLua.LanguageServer.Framework.Protocol.Model.Markup;
using EmmyLua.LanguageServer.Framework.Protocol.Union;

namespace EmmyLua.LanguageServer.Framework.Protocol.Supplement;

public record Hover
{
    [JsonPropertyName("contents")] public required MarkedStringsOrMarkupContent Contents { get; init; }
    [JsonPropertyName("range")] public DocumentRange? Range { get; init; }
}
