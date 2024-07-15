using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Model.Markup;

/**
 * A `MarkupContent` literal represents a string value whose content is
 * interpreted based on its kind flag. Currently, the protocol supports
 * `plaintext` and `markdown` as markup kinds.
 *
 * If the kind is `markdown` then the value can contain fenced code blocks like
 * in GitHub issues.
 *
 * Here is an example how such a string can be constructed using
 * JavaScript / TypeScript:
 * ```typescript
 * let markdown: MarkdownContent = {
 * 	kind: MarkupKind.Markdown,
 * 	value: [
 * 		'# Header',
 * 		'Some text',
 * 		'```typescript',
 * 		'someCode();',
 * 		'```'
 * 	].join('\n')
 * };
 * ```
 *
 * *Please Note* that clients might sanitize the returned markdown. A client
 * could decide to remove HTML from the markdown to avoid script execution.
 */
public class MarkupContent
{
    /**
     * The type of the Markup.
     */
    [JsonPropertyName("kind")]
    public MarkupKind Kind { get; set; } = MarkupKind.Markdown;

    /**
     * The content itself.
     */
    [JsonPropertyName("value")]
    public string Value { get; set; } = string.Empty;
}
