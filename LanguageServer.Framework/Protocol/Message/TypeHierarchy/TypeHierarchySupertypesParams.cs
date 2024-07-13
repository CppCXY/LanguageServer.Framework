using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Interface;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.TypeHierarchy;

public class TypeHierarchySupertypesParams : IWorkDoneProgressParams, IPartialResultParams
{
    [JsonPropertyName("workDoneToken")]
    public string? WorkDoneToken { get; set; }

    [JsonPropertyName("partialResultToken")]
    public string? PartialResultToken { get; set; }

    [JsonPropertyName("item")]
    public TypeHierarchyItem Item { get; set; } = null!;
}
