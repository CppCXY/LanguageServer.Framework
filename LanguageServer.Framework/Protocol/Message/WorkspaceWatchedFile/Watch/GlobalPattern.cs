using System.Text.Json;
using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.WorkspaceWatchedFile.Watch;


[JsonConverter(typeof(GlobalPatternJsonConverter))]
public class GlobalPattern
{
    public object Pattern { get; set; }

    public GlobalPattern(Pattern pattern)
    {
        Pattern = pattern;
    }

    public GlobalPattern(string pattern) : this(new Pattern(pattern))
    {
    }

    public GlobalPattern(RelativePattern relativePattern)
    {
        Pattern = relativePattern;
    }


    public static implicit operator GlobalPattern(Pattern pattern) => new GlobalPattern(pattern);

    public static implicit operator GlobalPattern(string pattern) => new GlobalPattern(pattern);

    public static implicit operator GlobalPattern(RelativePattern relativePattern) => new GlobalPattern(relativePattern);
}

public class GlobalPatternJsonConverter : JsonConverter<GlobalPattern>
{
    public override GlobalPattern Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, GlobalPattern value, JsonSerializerOptions options)
    {
        if (value.Pattern is Pattern pattern)
        {
            JsonSerializer.Serialize(writer, pattern, options);
        }
        else if (value.Pattern is RelativePattern relativePattern)
        {
            JsonSerializer.Serialize(writer, relativePattern, options);
        }
        else
        {
            throw new InvalidOperationException();
        }
    }
}

/**
 * The glob pattern to watch relative to the base path. Glob patterns can have
 * the following syntax:
 * - `*` to match one or more characters in a path segment
 * - `?` to match on one character in a path segment
 * - `**` to match any number of path segments, including none
 * - `{}` to group conditions (e.g. `**​/*.{ts,js}` matches all TypeScript
 *   and JavaScript files)
 * - `[]` to declare a range of characters to match in a path segment
 *   (e.g., `example.[0-9]` to match on `example.0`, `example.1`, …)
 * - `[!...]` to negate a range of characters to match in a path segment
 *   (e.g., `example.[!0-9]` to match on `example.a`, `example.b`,
 *   but not `example.0`)
 *
 * @since 3.17.0
 */
[JsonConverter(typeof(PatternJsonConverter))]
public record struct Pattern(string Value);

public class PatternJsonConverter : JsonConverter<Pattern>
{
    public override Pattern Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return new Pattern(reader.GetString()!);
    }

    public override void Write(Utf8JsonWriter writer, Pattern value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Value);
    }
}

/**
 * A relative pattern is a helper to construct glob patterns that are matched
 * relatively to a base URI. The common value for a `baseUri` is a workspace
 * folder root, but it can be another absolute URI as well.
 *
 * @since 3.17.0
 */
public class RelativePattern
{
    /**
     * A workspace folder or a base URI to which this pattern will be matched
     * against relatively.
     */
    [JsonPropertyName("base")]
    public DocumentUri BaseUri { get; set; }

    /**
     * The pattern to match under the base URI.
     */
    [JsonPropertyName("pattern")]
    public Pattern Pattern { get; set; }
}
