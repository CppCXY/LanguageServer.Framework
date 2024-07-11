﻿using System.Text.Json;
using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server.Options;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server.Union;
using EmmyLua.LanguageServer.Framework.Protocol.Model.Kind;
using EmmyLua.LanguageServer.Framework.Protocol.Model.Union;

namespace EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;

/// <summary>
/// If the definitions here do not meet your requirements, you can inherit from this class
/// </summary>
public class ServerCapabilities
{
    /**
     * The position encoding the server picked from the encodings offered
     * by the client via the client capability `general.positionEncodings`.
     *
     * If the client didn't provide any position encodings the only valid
     * value that a server can return is 'utf-16'.
     *
     * If omitted it defaults to 'utf-16'.
     *
     * @since 3.17.0
     */
    [JsonPropertyName("positionEncoding")]
    public PositionEncodingKind? PositionEncoding { get; set; }

    /**
     * Defines how text documents are synced. Is either a detailed structure
     * defining each notification or for backwards compatibility the
     * TextDocumentSyncKind number. If omitted it defaults to
     * `TextDocumentSyncKind.None`.
     */
    [JsonPropertyName("textDocumentSync")]
    public TextDocumentSyncOptionsOrKind? TextDocumentSync { get; set; }

    /**
     * Defines how notebook documents are synced.
     *
     * @since 3.17.0
     */
    [JsonPropertyName("notebookDocumentSync")]
    public NotebookDocumentSyncOptions? NotebookDocumentSync { get; set; }

    /**
     * The server provides completion support.
     */
    [JsonPropertyName("completionProvider")]
    public CompletionOptions? CompletionProvider { get; set; }

    /**
     * The server provides hover support.
     */
    [JsonPropertyName("hoverProvider")]
    public BooleanOr<HoverOptions>? HoverProvider { get; set; }

    /**
     * The server provides signature help support.
     */
    [JsonPropertyName("signatureHelpProvider")]
    public SignatureHelpOptions? SignatureHelpProvider { get; set; }

    /**
     * The server provides go to declaration support.
     *
     * @since 3.14.0
     */
    [JsonPropertyName("declarationProvider")]
    public BooleanOr<DeclarationOptions>? DeclarationProvider { get; set; }

    /**
     * The server provides goto definition support.
     */
    [JsonPropertyName("definitionProvider")]
    public BooleanOr<DefinitionOptions>? DefinitionProvider { get; set; }

    /**
     * The server provides goto type definition support.
     *
     * @since 3.6.0
     */
    [JsonPropertyName("typeDefinitionProvider")]
    public BooleanOr<TypeDefinitionOptions>? TypeDefinitionProvider { get; set; }

    /**
     * The server provides goto implementation support.
     *
     * @since 3.6.0
     */
    [JsonPropertyName("implementationProvider")]
    public BooleanOr<ImplementationOptions>? ImplementationProvider { get; set; }

    /**
     * The server provides find references support.
     */
    [JsonPropertyName("referencesProvider")]
    public BooleanOr<ReferencesOptions>? ReferencesProvider { get; set; }

    /**
     * The server provides document highlight support.
     */
    [JsonPropertyName("documentHighlightProvider")]
    public BooleanOr<DocumentHighlightOptions>? DocumentHighlightProvider { get; set; }

    /**
     * The server provides document symbol support.
     */
    [JsonPropertyName("documentSymbolProvider")]
    public BooleanOr<DocumentSymbolOptions>? DocumentSymbolProvider { get; set; }

    /**
     * The server provides code actions. The `CodeActionOptions` return type is
     * only valid if the client signals code action literal support via the
     * property `textDocument.codeAction.codeActionLiteralSupport`.
     */
    [JsonPropertyName("codeActionProvider")]
    public BooleanOr<CodeActionOptions>? CodeActionProvider { get; set; }

    /**
     * The server provides code lens.
     */
    [JsonPropertyName("codeLensProvider")]
    public CodeLensOptions? CodeLensProvider { get; set; }

    /**
     * The server provides document link support.
     */
    [JsonPropertyName("documentLinkProvider")]
    public DocumentLinkOptions? DocumentLinkProvider { get; set; }

    /**
     * The server provides color provider support.
     *
     * @since 3.6.0
     */
    [JsonPropertyName("colorProvider")]
    public BooleanOr<DocumentColorOptions>? ColorProvider { get; set; }

    /**
     * The server provides document formatting.
     */
    [JsonPropertyName("documentFormattingProvider")]
    public BooleanOr<DocumentFormattingOptions>? DocumentFormattingProvider { get; set; }

    /**
     * The server provides document range formatting.
     */
    [JsonPropertyName("documentRangeFormattingProvider")]
    public BooleanOr<DocumentRangeFormattingOptions>? DocumentRangeFormattingProvider { get; set; }

    /**
     * The server provides document formatting on typing.
     */
    [JsonPropertyName("documentOnTypeFormattingProvider")]
    public DocumentOnTypeFormattingOptions? DocumentOnTypeFormattingProvider { get; set; }

    /**
     * The server provides execute command support.
     */
    [JsonPropertyName("executeCommandProvider")]
    public ExecuteCommandOptions? ExecuteCommandProvider { get; set; }

    /**
     * The server provides selection range support.
     *
     * @since 3.15.0
     */
    [JsonPropertyName("selectionRangeProvider")]
    public BooleanOr<SelectionRangeOptions>? SelectionRangeProvider { get; set; }

    /**
     * The server provides linked editing range support.
     *
     * @since 3.16.0
     */
    [JsonPropertyName("linkedEditingRangeProvider")]
    public BooleanOr<LinkedEditingRangeOptions>? LinkedEditingRangeProvider { get; set; }

    /**
     * The server provides call hierarchy support.
     *
     * @since 3.16.0
     */
    [JsonPropertyName("callHierarchyProvider")]
    public BooleanOr<CallHierarchyOptions>? CallHierarchyProvider { get; set; }

    /**
     * The server provides semantic tokens support.
     *
     * @since 3.16.0
     */
    [JsonPropertyName("semanticTokensProvider")]
    public SemanticTokensOptions? SemanticTokensProvider { get; set; }

    /**
     * Whether server provides moniker support.
     *
     * @since 3.16.0
     */
    [JsonPropertyName("monikerProvider")]
    public BooleanOr<MonikerOptions>? MonikerProvider { get; set; }

    /**
     * The server provides type hierarchy support.
     *
     * @since 3.17.0
     */
    [JsonPropertyName("typeHierarchyProvider")]
    public BooleanOr<TypeHierarchyOptions>? TypeHierarchyProvider { get; set; }

    /**
     * The server provides inline values.
     *
     * @since 3.17.0
     */
    [JsonPropertyName("inlineValuesProvider")]
    public BooleanOr<InlineValuesOptions>? InlineValuesProvider { get; set; }

    /**
     * The server provides inlay hints.
     *
     * @since 3.17.0
     */
    [JsonPropertyName("inlayHintsProvider")]
    public BooleanOr<InlayHintsOptions>? InlayHintsProvider { get; set; }

    /**
     * The server has support for pull model diagnostics.
     *
     * @since 3.17.0
     */
    [JsonPropertyName("diagnosticProvider")]
    public DiagnosticOptions? DiagnosticProvider { get; set; }

    /**
     * The server provides workspace symbol support.
     */
    [JsonPropertyName("workspaceSymbolProvider")]
    public BooleanOr<WorkspaceSymbolOptions>? WorkspaceSymbolProvider { get; set; }

    /**
     * The server provides inline completions.
     *
     * @since 3.18.0
     */
    [JsonPropertyName("inlineCompletionsProvider")]
    public BooleanOr<InlineCompletionsOptions>? InlineCompletionsProvider { get; set; }

    /**
     * Text document specific server capabilities.
     *
     * @since 3.18.0
     */
    [JsonPropertyName("textDocument")]
    public TextDocumentServerCapabilities? TextDocument { get; set; }

    /**
     * Workspace specific server capabilities
     */
    [JsonPropertyName("workspace")]
    public WorkspaceServerCapabilities.WorkspaceServerCapabilities? Workspace { get; set; }

    /**
     * Experimental server capabilities.
     */
    [JsonPropertyName("experimental")]
    public JsonDocument? Experimental { get; set; }
}

