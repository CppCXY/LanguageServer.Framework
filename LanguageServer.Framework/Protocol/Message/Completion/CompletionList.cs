using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;
using EmmyLua.LanguageServer.Framework.Protocol.Model.Kind;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.Completion;

/**
 * Represents a collection of [completion items](#CompletionItem) to be
 * presented in the editor.
 */
public class CompletionList
{
    /**
     * This list is not complete. Further typing should result in recomputing
     * this list.
     *
     * Recomputed lists have all their items replaced (not appended) in the
     * incomplete completion sessions.
     */
    [JsonPropertyName("isIncomplete")]
    public bool IsIncomplete { get; set; }

    /**
     * In many cases, the items of an actual completion result share the same
     * value for properties like `commitCharacters` or the range of a text
     * edit. A completion list can therefore define item defaults which will
     * be used if a completion item itself doesn't specify the value.
     *
     * If a completion list specifies a default value and a completion item
     * also specifies a corresponding value, the one from the item is used.
     *
     * Servers are only allowed to return default values if the client
     * signals support for this via the `completionList.itemDefaults`
     * capability.
     *
     * @since 3.17.0
     */
    [JsonPropertyName("itemDefaults")]
    public CompletionListItemDefault? ItemDefaults { get; set; }

    /**
     * The completion items.
     */
    [JsonPropertyName("items")]
    public List<CompletionItem> Items { get; set; } = null!;
}

public class CompletionListItemDefault
{
    /**
     * The default commit characters.
     */
    [JsonPropertyName("commitCharacters")]
    public List<string>? CommitCharacters { get; set; }

    /**
     * The default range.
     */
    [JsonPropertyName("editRange")]
    public CompletionListItemDefaultEditRange? EditRange { get; set; }

    /**
     * A default insert text format.
     *
     * @since 3.17.0
     */
    [JsonPropertyName("insertTextFormat")]
    public InsertTextFormat? InsertTextFormat { get; set; }

    /**
     * The default insert text mode.
     *
     * @since 3.17.0
     */
    [JsonPropertyName("insertTextMode")]
    public InsertTextMode? InsertTextMode { get; set; }

    /**
     * A default data value.
     *
     * @since 3.17.0
     */
    [JsonPropertyName("data")]
    public LSPAny? Data { get; set; }
}

[JsonConverter(typeof(CompletionListItemDefaultEditRangeJsonConverter))]
public class CompletionListItemDefaultEditRange
{
    public DocumentRange? Result1 { get; set; }

    public InsertAndReplaceRange? Result2 { get; set; }

    public CompletionListItemDefaultEditRange(DocumentRange range)
    {
        Result1 = range;
    }

    public CompletionListItemDefaultEditRange(InsertAndReplaceRange range)
    {
        Result2 = range;
    }
}

public class CompletionListItemDefaultEditRangeJsonConverter : JsonConverter<CompletionListItemDefaultEditRange>
{
    public override CompletionListItemDefaultEditRange Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        throw new UnreachableException();
    }

    public override void Write(Utf8JsonWriter writer, CompletionListItemDefaultEditRange value,
        JsonSerializerOptions options)
    {
        if (value.Result1.HasValue)
        {
            JsonSerializer.Serialize(writer, value.Result1.Value, options);
        }
        else if (value.Result2 != null)
        {
            JsonSerializer.Serialize(writer, value.Result2, options);
        }
        else
        {
            throw new JsonException();
        }
    }
}

public class InsertAndReplaceRange
{
    [JsonPropertyName("insert")]
    public DocumentRange Insert { get; set; }

    [JsonPropertyName("replace")]
    public DocumentRange Replace { get; set; }
}
