using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.LinkedEditingRange;


public class LinkedEditingRanges
{
    /**
     * A list of ranges that can be renamed together. The ranges must have
     * identical length and contain identical text content. The ranges cannot
     * overlap.
    */
    [JsonPropertyName("ranges")]
    public List<DocumentRange> Ranges { get; set; } = null!;

    /**
     * An optional word pattern for the language.
     *
     * If specified, the client should use this pattern to determine which characters
     * are word separators in the language.
     */
    [JsonPropertyName("wordPattern")]
    public string? WordPattern { get; set; }
}
