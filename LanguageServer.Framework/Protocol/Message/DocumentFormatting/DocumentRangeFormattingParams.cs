using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Interface;
using EmmyLua.LanguageServer.Framework.Protocol.Model;
using EmmyLua.LanguageServer.Framework.Protocol.Model.TextDocument;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentFormatting;

public class DocumentRangeFormattingParams : IWorkDoneProgressParams
{
    [JsonPropertyName("workDoneToken")]
    public string? WorkDoneToken { get; set; }

    /**
     * The document to format.
     */
    [JsonPropertyName("textDocument")]
    public TextDocumentIdentifier TextDocument { get; set; } = null!;

    /**
     * The range to format
     */
    [JsonPropertyName("range")]
    public DocumentRange Range { get; set; }

    /**
     * The format options
     */
    [JsonPropertyName("options")]
    public FormattingOptions Options { get; set; } = null!;
}

public class DocumentRangesFormattingParams : IWorkDoneProgressParams
{
    [JsonPropertyName("workDoneToken")]
    public string? WorkDoneToken { get; set; }

    /**
     * The document to format.
     */
    [JsonPropertyName("textDocument")]
    public TextDocumentIdentifier TextDocument { get; set; } = null!;

    /**
     * The ranges to format
     */
    [JsonPropertyName("ranges")]
    public List<DocumentRange> Ranges { get; set; } = null!;

    /**
     * The format options
     */
    [JsonPropertyName("options")]
    public FormattingOptions Options { get; set; } = null!;
}
