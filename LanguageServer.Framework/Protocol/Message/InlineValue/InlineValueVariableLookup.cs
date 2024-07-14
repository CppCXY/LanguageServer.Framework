using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.InlineValue;

/**
 * Provide inline value through a variable lookup.
 *
 * If only a range is specified, the variable name will be extracted from
 * the underlying document.
 *
 * An optional variable name can be used to override the extracted name.
 *
 * @since 3.17.0
 */
public class InlineValueVariableLookup
{
    /**
     * The document range for which the inline value applies.
     * The range is used to extract the variable name from the underlying
     * document.
     */
    [JsonPropertyName("range")]
    public DocumentRange Range { get; set; }

    /**
     * If specified, the name of the variable to look up.
     */
    [JsonPropertyName("variableName")]
    public string? VariableName { get; set; }

    /**
     * How to perform the lookup.
     */
    [JsonPropertyName("caseSensitiveLookup")]
    public bool CaseSensitiveLookup { get; set; }
}
