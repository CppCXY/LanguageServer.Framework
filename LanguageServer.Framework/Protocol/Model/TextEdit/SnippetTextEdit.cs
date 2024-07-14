﻿using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Model.TextEdit;

/**
 * An interactive text edit.
 *
 * @since 3.18.0
 */
[method: JsonConstructor]
public record struct SnippetTextEdit(DocumentRange Range, StringValue Snippet, string? AnnotationId = null)
{
    /**
     * The range of the text document to be manipulated.
     */
    [JsonPropertyName("range")]
    public DocumentRange Range { get; } = Range;

    /**
     * The snippet to be inserted.
     */
    [JsonPropertyName("snippet")]
    public StringValue Snippet { get; } = Snippet;

    /**
     * An optional identifier of the actual annotation.
     */
    [JsonPropertyName("annotationId")]
    public string? AnnotationId { get; } = AnnotationId;
}
