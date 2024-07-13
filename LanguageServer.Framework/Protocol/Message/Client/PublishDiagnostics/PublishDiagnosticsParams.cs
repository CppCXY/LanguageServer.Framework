using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;
using EmmyLua.LanguageServer.Framework.Protocol.Model.Diagnostic;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.Client.PublishDiagnostics;

public class PublishDiagnosticsParams
{
    /**
     * The URI for which diagnostic information is reported.
     */
    [JsonPropertyName("uri")]
    public DocumentUri Uri { get; set; }


    /**
     * Optionally, the version number of the document the diagnostics are
     * published for.
     *
     * @since 3.15.0
     */
    [JsonPropertyName("version")]
    public int? Version { get; set; }

    /**
     * An array of diagnostic information items.
     */
    [JsonPropertyName("diagnostics")]
    public List<Diagnostic> Diagnostics { get; set; } = null!;
}
