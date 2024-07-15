using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.WorkspaceEditClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server.Options;
using EmmyLua.LanguageServer.Framework.Protocol.JsonRpc;
using EmmyLua.LanguageServer.Framework.Protocol.Message;
using EmmyLua.LanguageServer.Framework.Protocol.Message.CallHierarchy;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Client.ApplyWorkspaceEdit;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Client.PublishDiagnostics;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Client.Registration;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Client.ShowMessage;
using EmmyLua.LanguageServer.Framework.Protocol.Message.CodeAction;
using EmmyLua.LanguageServer.Framework.Protocol.Message.CodeLens;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Completion;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Configuration;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Declaration;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Definition;
using EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentColor;
using EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentDiagnostic;
using EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentFormatting;
using EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentHighlight;
using EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentLink;
using EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentSymbol;
using EmmyLua.LanguageServer.Framework.Protocol.Message.ExecuteCommand;
using EmmyLua.LanguageServer.Framework.Protocol.Message.FoldingRange;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Hover;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Implementation;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Initialize;
using EmmyLua.LanguageServer.Framework.Protocol.Message.InlayHint;
using EmmyLua.LanguageServer.Framework.Protocol.Message.InlineCompletion;
using EmmyLua.LanguageServer.Framework.Protocol.Message.InlineValue;
using EmmyLua.LanguageServer.Framework.Protocol.Message.LinkedEditingRange;
using EmmyLua.LanguageServer.Framework.Protocol.Message.NotebookDocument;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Reference;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Rename;
using EmmyLua.LanguageServer.Framework.Protocol.Message.SelectionRange;
using EmmyLua.LanguageServer.Framework.Protocol.Message.SemanticToken;
using EmmyLua.LanguageServer.Framework.Protocol.Message.SignatureHelp;
using EmmyLua.LanguageServer.Framework.Protocol.Message.TextDocument;
using EmmyLua.LanguageServer.Framework.Protocol.Message.TypeDefinition;
using EmmyLua.LanguageServer.Framework.Protocol.Message.TypeHierarchy;
using EmmyLua.LanguageServer.Framework.Protocol.Message.WorkspaceDiagnostic;
using EmmyLua.LanguageServer.Framework.Protocol.Message.WorkspaceFiles;
using EmmyLua.LanguageServer.Framework.Protocol.Message.WorkspaceFolders;
using EmmyLua.LanguageServer.Framework.Protocol.Message.WorkspaceSymbol;
using EmmyLua.LanguageServer.Framework.Protocol.Message.WorkspaceWatchedFile;
using EmmyLua.LanguageServer.Framework.Protocol.Message.WorkspaceWatchedFile.Watch;
using EmmyLua.LanguageServer.Framework.Protocol.Model;
using EmmyLua.LanguageServer.Framework.Protocol.Model.Diagnostic;
using EmmyLua.LanguageServer.Framework.Protocol.Model.File;
using EmmyLua.LanguageServer.Framework.Protocol.Model.Kind;
using EmmyLua.LanguageServer.Framework.Protocol.Model.Markup;
using EmmyLua.LanguageServer.Framework.Protocol.Model.TextDocument;
using EmmyLua.LanguageServer.Framework.Protocol.Model.TextEdit;
using EmmyLua.LanguageServer.Framework.Protocol.Model.Union;
using EmmyLua.LanguageServer.Framework.Protocol.Model.WorkDoneProgress;
using FileSystemWatcher = EmmyLua.LanguageServer.Framework.Protocol.Message.WorkspaceWatchedFile.Watch.FileSystemWatcher;
using FoldingRangeKind = EmmyLua.LanguageServer.Framework.Protocol.Message.FoldingRange.FoldingRangeKind;


namespace EmmyLua.LanguageServer.Framework.Protocol;

[JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Metadata)]
[JsonSerializable(typeof(uint))]
[JsonSerializable(typeof(int))]
[JsonSerializable(typeof(bool))]
[JsonSerializable(typeof(int?))]
[JsonSerializable(typeof(bool?))]
[JsonSerializable(typeof(uint?))]
[JsonSerializable(typeof(string))]
[JsonSerializable(typeof(Uri))]
[JsonSerializable(typeof(JsonRpc.Message))]
[JsonSerializable(typeof(MethodMessage))]
[JsonSerializable(typeof(RequestMessage))]
[JsonSerializable(typeof(ResponseMessage))]
[JsonSerializable(typeof(NotificationMessage))]
[JsonSerializable(typeof(ResponseError))]
[JsonSerializable(typeof(InitializeParams))]
[JsonSerializable(typeof(InitializeResult))]
[JsonSerializable(typeof(ClientInfo))]
[JsonSerializable(typeof(DocumentUri))]
[JsonSerializable(typeof(DocumentFilter))]
[JsonSerializable(typeof(DocumentRange))]
[JsonSerializable(typeof(List<DocumentRange>))]
[JsonSerializable(typeof(Position))]
[JsonSerializable(typeof(List<Position>))]
[JsonSerializable(typeof(Location))]
[JsonSerializable(typeof(List<Location>))]
[JsonSerializable(typeof(LocationLink))]
[JsonSerializable(typeof(List<LocationLink>))]
[JsonSerializable(typeof(TextDocumentIdentifier))]
[JsonSerializable(typeof(TextDocumentItem))]
[JsonSerializable(typeof(VersionedTextDocumentIdentifier))]
[JsonSerializable(typeof(TextDocumentEdit))]
[JsonSerializable(typeof(AnnotatedTextEdit))]
[JsonSerializable(typeof(MarkupContent))]
[JsonSerializable(typeof(Command))]
[JsonSerializable(typeof(SnippetTextEdit))]
[JsonSerializable(typeof(List<SnippetTextEdit>))]
[JsonSerializable(typeof(TextEdit))]
[JsonSerializable(typeof(List<TextEdit>))]
[JsonSerializable(typeof(InsertReplaceEdit))]
[JsonSerializable(typeof(List<InsertReplaceEdit>))]
[JsonSerializable(typeof(WorkspaceEdit))]
[JsonSerializable(typeof(TraceValue))]
[JsonSerializable(typeof(ChangeAnnotation))]
[JsonSerializable(typeof(Diagnostic))]
[JsonSerializable(typeof(DiagnosticSeverity))]
[JsonSerializable(typeof(DiagnosticTag))]
[JsonSerializable(typeof(DiagnosticRelatedInformation))]
[JsonSerializable(typeof(CreateFile))]
[JsonSerializable(typeof(CreateFileOptions))]
[JsonSerializable(typeof(RenameFile))]
[JsonSerializable(typeof(RenameFileOptions))]
[JsonSerializable(typeof(DeleteFile))]
[JsonSerializable(typeof(DeleteFileOptions))]
[JsonSerializable(typeof(ChangeAnnotationIdentifier))]
[JsonSerializable(typeof(WorkDoneProgressBegin))]
[JsonSerializable(typeof(WorkDoneProgressReport))]
[JsonSerializable(typeof(WorkDoneProgressEnd))]
[JsonSerializable(typeof(CodeActionKind))]
[JsonSerializable(typeof(CompletionItemKind))]
[JsonSerializable(typeof(FoldingRangeKind))]
[JsonSerializable(typeof(InsertTextMode))]
[JsonSerializable(typeof(PositionEncodingKind))]
[JsonSerializable(typeof(ResourceOperationKind))]
[JsonSerializable(typeof(PrepareSupportDefaultBehavior))]
[JsonSerializable(typeof(SymbolKind))]
[JsonSerializable(typeof(SymbolTag))]
[JsonSerializable(typeof(TokenFormat))]
[JsonSerializable(typeof(StringOrInt))]
[JsonSerializable(typeof(StringOrMarkupContent))]
[JsonSerializable(typeof(MarkupContent))]
[JsonSerializable(typeof(WorkspaceEditDocumentChanges))]
[JsonSerializable(typeof(ServerCapabilities))]
[JsonSerializable(typeof(InitializeResult))]
[JsonSerializable(typeof(InitializedParams))]
[JsonSerializable(typeof(RegistrationParams))]
[JsonSerializable(typeof(UnregistrationParams))]
[JsonSerializable(typeof(CancelParams))]
[JsonSerializable(typeof(TextDocumentSyncOptions))]
[JsonSerializable(typeof(DidOpenTextDocumentParams))]
[JsonSerializable(typeof(DidChangeTextDocumentParams))]
[JsonSerializable(typeof(DidCloseTextDocumentParams))]
[JsonSerializable(typeof(DidSaveTextDocumentParams))]
[JsonSerializable(typeof(WillSaveTextDocumentParams))]
[JsonSerializable(typeof(DidOpenNotebookDocumentParams))]
[JsonSerializable(typeof(DidChangeNotebookDocumentParams))]
[JsonSerializable(typeof(DidCloseNotebookDocumentParams))]
[JsonSerializable(typeof(DidSaveNotebookDocumentParams))]
[JsonSerializable(typeof(DeclarationParams))]
[JsonSerializable(typeof(DeclarationResponse))]
[JsonSerializable(typeof(DefinitionParams))]
[JsonSerializable(typeof(DefinitionResponse))]
[JsonSerializable(typeof(TypeDefinitionParams))]
[JsonSerializable(typeof(TypeDefinitionResponse))]
[JsonSerializable(typeof(ImplementationParams))]
[JsonSerializable(typeof(ImplementationResponse))]
[JsonSerializable(typeof(ReferenceParams))]
[JsonSerializable(typeof(ReferenceResponse))]
[JsonSerializable(typeof(CallHierarchyItem))]
[JsonSerializable(typeof(List<CallHierarchyItem>))]
[JsonSerializable(typeof(CallHierarchyPrepareParams))]
[JsonSerializable(typeof(CallHierarchyPrepareResponse))]
[JsonSerializable(typeof(CallHierarchyIncomingCallsParams))]
[JsonSerializable(typeof(CallHierarchyIncomingCallsResponse))]
[JsonSerializable(typeof(CallHierarchyIncomingCall))]
[JsonSerializable(typeof(List<CallHierarchyIncomingCall>))]
[JsonSerializable(typeof(CallHierarchyOutgoingCallsParams))]
[JsonSerializable(typeof(CallHierarchyOutgoingCallsResponse))]
[JsonSerializable(typeof(CallHierarchyOutgoingCall))]
[JsonSerializable(typeof(List<CallHierarchyOutgoingCall>))]
[JsonSerializable(typeof(CompletionParams))]
[JsonSerializable(typeof(CompletionResponse))]
[JsonSerializable(typeof(List<CompletionItem>))]
[JsonSerializable(typeof(CompletionList))]
[JsonSerializable(typeof(InsertAndReplaceRange))]
[JsonSerializable(typeof(HoverParams))]
[JsonSerializable(typeof(HoverResponse))]
[JsonSerializable(typeof(SignatureHelpParams))]
[JsonSerializable(typeof(DocumentHighlightParams))]
[JsonSerializable(typeof(DocumentHighlightResponse))]
[JsonSerializable(typeof(List<DocumentHighlight>))]
[JsonSerializable(typeof(DocumentSymbolParams))]
[JsonSerializable(typeof(DocumentSymbolResponse))]
[JsonSerializable(typeof(List<DocumentSymbol>))]
[JsonSerializable(typeof(CodeAction))]
[JsonSerializable(typeof(List<CodeAction>))]
[JsonSerializable(typeof(CodeActionParams))]
[JsonSerializable(typeof(CodeActionResponse))]
[JsonSerializable(typeof(CommandOrCodeAction))]
[JsonSerializable(typeof(List<CommandOrCodeAction>))]
[JsonSerializable(typeof(Registration))]
[JsonSerializable(typeof(CodeLens))]
[JsonSerializable(typeof(List<CodeLens>))]
[JsonSerializable(typeof(CodeLensParams))]
[JsonSerializable(typeof(CodeLensResponse))]
[JsonSerializable(typeof(DocumentLinkParams))]
[JsonSerializable(typeof(DocumentLinkResponse))]
[JsonSerializable(typeof(DocumentLink))]
[JsonSerializable(typeof(List<DocumentLink>))]
[JsonSerializable(typeof(DocumentColorParams))]
[JsonSerializable(typeof(DocumentColorResponse))]
[JsonSerializable(typeof(ColorInformation))]
[JsonSerializable(typeof(List<ColorInformation>))]
[JsonSerializable(typeof(ColorPresentationParams))]
[JsonSerializable(typeof(ColorPresentationResponse))]
[JsonSerializable(typeof(ColorPresentation))]
[JsonSerializable(typeof(List<ColorPresentation>))]
[JsonSerializable(typeof(DocumentFormattingParams))]
[JsonSerializable(typeof(DocumentFormattingResponse))]
[JsonSerializable(typeof(DocumentRangeFormattingParams))]
[JsonSerializable(typeof(DocumentRangesFormattingParams))]
[JsonSerializable(typeof(DocumentOnTypeFormattingParams))]
[JsonSerializable(typeof(RenameParams))]
[JsonSerializable(typeof(PrepareRenameParams))]
[JsonSerializable(typeof(PrepareRenameResponse))]
[JsonSerializable(typeof(FoldingRangeParams))]
[JsonSerializable(typeof(FoldingRangeResponse))]
[JsonSerializable(typeof(FoldingRange))]
[JsonSerializable(typeof(List<FoldingRange>))]
[JsonSerializable(typeof(FoldingRangeKind))]
[JsonSerializable(typeof(ExecuteCommandParams))]
[JsonSerializable(typeof(ExecuteCommandResponse))]
[JsonSerializable(typeof(ApplyWorkspaceEditParams))]
[JsonSerializable(typeof(ApplyWorkspaceEditResult))]
[JsonSerializable(typeof(ShowMessageParams))]
[JsonSerializable(typeof(MessageType))]
[JsonSerializable(typeof(SelectionRangeParams))]
[JsonSerializable(typeof(SelectionRangeResponse))]
[JsonSerializable(typeof(SelectionRange))]
[JsonSerializable(typeof(List<SelectionRange>))]
[JsonSerializable(typeof(LinkedEditingRangeParams))]
[JsonSerializable(typeof(LinkedEditingRanges))]
[JsonSerializable(typeof(List<LinkedEditingRanges>))]
[JsonSerializable(typeof(SemanticTokensParams))]
[JsonSerializable(typeof(SemanticTokensDeltaResponse))]
[JsonSerializable(typeof(SemanticTokensPartialResult))]
[JsonSerializable(typeof(SemanticTokensDeltaPartialResult))]
[JsonSerializable(typeof(SemanticTokensEdit))]
[JsonSerializable(typeof(List<SemanticTokensEdit>))]
[JsonSerializable(typeof(SemanticTokensRangeParams))]
[JsonSerializable(typeof(SemanticTokens))]
[JsonSerializable(typeof(TypeHierarchyItem))]
[JsonSerializable(typeof(List<TypeHierarchyItem>))]
[JsonSerializable(typeof(TypeHierarchyResponse))]
[JsonSerializable(typeof(TypeHierarchyPrepareParams))]
[JsonSerializable(typeof(TypeHierarchySupertypesParams))]
[JsonSerializable(typeof(TypeHierarchySubtypesParams))]
[JsonSerializable(typeof(InlineValueParams))]
[JsonSerializable(typeof(InlineValueResponse))]
[JsonSerializable(typeof(InlineValue))]
[JsonSerializable(typeof(List<InlineValue>))]
[JsonSerializable(typeof(InlineValueText))]
[JsonSerializable(typeof(InlineValueVariableLookup))]
[JsonSerializable(typeof(InlineValueEvaluatableExpression))]
[JsonSerializable(typeof(InlayHintParams))]
[JsonSerializable(typeof(InlayHintResponse))]
[JsonSerializable(typeof(InlayHint))]
[JsonSerializable(typeof(List<InlayHint>))]
[JsonSerializable(typeof(InlayHintLabelPart))]
[JsonSerializable(typeof(List<InlayHintLabelPart>))]
[JsonSerializable(typeof(PublishDiagnosticsParams))]
[JsonSerializable(typeof(DocumentDiagnosticParams))]
[JsonSerializable(typeof(DocumentDiagnosticReport))]
[JsonSerializable(typeof(FullOrUnchangeDocumentDiagnosticReport))]
[JsonSerializable(typeof(FullDocumentDiagnosticReport))]
[JsonSerializable(typeof(UnchangedDocumentDiagnosticReport))]
[JsonSerializable(typeof(RelatedFullDocumentDiagnosticReport))]
[JsonSerializable(typeof(RelatedUnchangedDocumentDiagnosticReport))]
[JsonSerializable(typeof(List<Diagnostic>))]
[JsonSerializable(typeof(DocumentDiagnosticReportPartialResult))]
[JsonSerializable(typeof(PreviousResultId))]
[JsonSerializable(typeof(WorkspaceDocumentDiagnosticReport))]
[JsonSerializable(typeof(WorkspaceDiagnosticReport))]
[JsonSerializable(typeof(WorkspaceDiagnosticReportPartialResult))]
[JsonSerializable(typeof(List<WorkspaceDocumentDiagnosticReport>))]
[JsonSerializable(typeof(WorkspaceDiagnosticParams))]
[JsonSerializable(typeof(WorkspaceFullDocumentDiagnosticReport))]
[JsonSerializable(typeof(WorkspaceUnchangedDocumentDiagnosticReport))]
[JsonSerializable(typeof(WorkspaceSymbol))]
[JsonSerializable(typeof(WorkspaceSymbolParams))]
[JsonSerializable(typeof(WorkspaceSymbolResponse))]
[JsonSerializable(typeof(List<WorkspaceSymbol>))]
[JsonSerializable(typeof(InlineCompletionItem))]
[JsonSerializable(typeof(InlineCompletionList))]
[JsonSerializable(typeof(InlineCompletionParams))]
[JsonSerializable(typeof(InlineCompletionResponse))]
[JsonSerializable(typeof(InlineCompletionTriggerKind))]
[JsonSerializable(typeof(SelectedCompletionInfo))]
[JsonSerializable(typeof(List<InlineCompletionItem>))]
[JsonSerializable(typeof(DidChangeWorkspaceFoldersParams))]
[JsonSerializable(typeof(WorkspaceFoldersChangeEvent))]
[JsonSerializable(typeof(CreateFilesParams))]
[JsonSerializable(typeof(RenameFilesParams))]
[JsonSerializable(typeof(DeleteFilesParams))]
[JsonSerializable(typeof(DidChangeWatchedFilesParams))]
[JsonSerializable(typeof(DidChangeWatchedFilesRegistrationOptions))]
[JsonSerializable(typeof(FileEvent))]
[JsonSerializable(typeof(List<FileEvent>))]
[JsonSerializable(typeof(FileChangeType))]
[JsonSerializable(typeof(WatchKind))]
[JsonSerializable(typeof(FileSystemWatcher))]
[JsonSerializable(typeof(GlobalPattern))]
[JsonSerializable(typeof(Pattern))]
[JsonSerializable(typeof(RelativePattern))]
[JsonSerializable(typeof(ConfigurationParams))]
[JsonSerializable(typeof(ConfigurationItem))]
[JsonSerializable(typeof(List<ConfigurationItem>))]
[JsonSerializable(typeof(List<LSPAny>))]
// ReSharper disable once ClassNeverInstantiated.Global
internal partial class JsonProtocolContext: JsonSerializerContext;
