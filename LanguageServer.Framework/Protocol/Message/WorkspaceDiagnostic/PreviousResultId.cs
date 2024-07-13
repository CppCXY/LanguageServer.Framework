using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.WorkspaceDiagnostic;

/**
 * A previous result ID in a workspace pull request.
 *
 * @since 3.17.0
 */
public class PreviousResultId
{
    /**
     * The URI for which the client knows a
     * result ID.
     */
    [JsonPropertyName("uri")]
    public DocumentUri Uri { get; set; }

    /**
     * The value of the previous result ID.
     */
    [JsonPropertyName("value")]
    public string Value { get; set; } = string.Empty;
}
