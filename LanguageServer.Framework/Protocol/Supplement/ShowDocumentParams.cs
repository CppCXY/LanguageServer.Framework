using System.Runtime.InteropServices;
using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace WCKYWCKF.EmmyLua.LanguageServer.Framework.ClientEx.Protocol;

public record ShowDocumentParams
{
    /// <summary>
    /// The document uri to show.
    /// </summary>
    [JsonPropertyName("uri")]
    public required DocumentUri Uri { get; init; }

    /// <summary>
    /// Indicates to show the resource in an external program.
    /// To show, for example, `https://code.visualstudio.com/`
    /// in the default WEB browser set `external` to `true`.
    /// </summary>
    [JsonPropertyName("external")]
    public bool? External { get; init; }

    /// <summary>
    /// An optional property to indicate whether the editor
    /// showing the document should take focus or not.
    /// Clients might ignore this property if an external
    /// program is started.
    /// </summary>
    [JsonPropertyName("takeFocus")]
    public bool? TakeFocus { get; init; }

    /// <summary>
    /// An optional selection range if the document is a text
    /// document. Clients might ignore the property if an
    /// external program is started or the file is not a text
    /// file.
    /// </summary>
    [JsonPropertyName("selection")]
    public Range? Selection { get; init; }
}