using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.InlineValue;

/**
 * Provide an inline value through an expression evaluation.
 *
 * If only a range is specified, the expression will be extracted from the
 * underlying document.
 *
 * An optional expression can be used to override the extracted expression.
 *
 * @since 3.17.0
 */
public class InlineValueEvaluatableExpression
{
    /**
     * The document range for which the inline value applies.
     * The range is used to extract the evaluatable expression from the
     * underlying document.
     */
    [JsonPropertyName("range")]
    public DocumentRange Range { get; set; }

    /**
     * If specified the expression overrides the extracted expression.
     */
    [JsonPropertyName("expression")]
    public string? Expression { get; set; }
}
