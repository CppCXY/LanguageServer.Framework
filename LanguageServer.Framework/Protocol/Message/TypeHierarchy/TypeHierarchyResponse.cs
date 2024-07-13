using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.TypeHierarchy;

[JsonConverter(typeof(TypeHierarchyResponseJsonConverter))]
public class TypeHierarchyResponse(List<TypeHierarchyItem> typeHierarchies)
{
     public List<TypeHierarchyItem> TypeHierarchies { get; set; } = typeHierarchies;
}

public class TypeHierarchyResponseJsonConverter : JsonConverter<TypeHierarchyResponse>
{
    public override TypeHierarchyResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, TypeHierarchyResponse value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.TypeHierarchies, options);
    }
}
