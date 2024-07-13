using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Interface;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.WorkspaceDiagnostic;

/**
 * Parameters of the workspace diagnostic request.
 *
 * @since 3.17.0
 */
public class WorkspaceDiagnosticParams : IWorkDoneProgressParams, IPartialResultParams
{
    [JsonPropertyName("workDoneToken")]
    public string? WorkDoneToken { get; set; }

    [JsonPropertyName("partialResultToken")]
    public string? PartialResultToken { get; set; }

    /**
     * The additional identifier provided during registration.
     */
    [JsonPropertyName("identifier")]
    public string? Identifier { get; set; } = null!;

    /**
     * The currently known diagnostic reports with their
     * previous result IDs.
     */
    [JsonPropertyName("previousResultIds")]
    public List<PreviousResultId> PreviousResultIds { get; set; } = null!;
}
