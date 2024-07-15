using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.CodeAction;

[JsonConverter(typeof(CodeActionResponseJsonConverter))]
public class CodeActionResponse
{
    public CodeActionResponse(List<CommandOrCodeAction> commandOrCodeActions)
    {
        CommandOrCodeActions = commandOrCodeActions;
    }

    public CodeActionResponse(List<Command> commands)
    {
        CommandOrCodeActions = commands.Select(c => new CommandOrCodeAction(c)).ToList();
    }

    public CodeActionResponse(List<CodeAction> codeActions)
    {
        CommandOrCodeActions = codeActions.Select(c => new CommandOrCodeAction(c)).ToList();
    }

    public List<CommandOrCodeAction> CommandOrCodeActions { get; set; }
}

public class CodeActionResponseJsonConverter : JsonConverter<CodeActionResponse>
{
    public override CodeActionResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new UnreachableException();
    }

    public override void Write(Utf8JsonWriter writer, CodeActionResponse value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.CommandOrCodeActions, options);
    }
}


[JsonConverter(typeof(CommandOrCodeActionJsonConverter))]
public class CommandOrCodeAction
{
    public CommandOrCodeAction(Command command)
    {
        Command = command;
    }

    public CommandOrCodeAction(CodeAction codeAction)
    {
        CodeAction = codeAction;
    }

    public Command? Command { get; }

    public CodeAction? CodeAction { get; }
}

public class CommandOrCodeActionJsonConverter : JsonConverter<CommandOrCodeAction>
{
    public override CommandOrCodeAction Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new UnreachableException();
    }

    public override void Write(Utf8JsonWriter writer, CommandOrCodeAction value, JsonSerializerOptions options)
    {
        if (value.Command != null)
        {
            JsonSerializer.Serialize(writer, value.Command, options);
        }
        else
        {
            JsonSerializer.Serialize(writer, value.CodeAction, options);
        }
    }
}
