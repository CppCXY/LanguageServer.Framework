using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server.Options;
using EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentColor;
using EmmyLua.LanguageServer.Framework.Protocol.Model;
using EmmyLua.LanguageServer.Framework.Server.Handler;
using Range = EmmyLua.LanguageServer.Framework.Protocol.Model.Range;

namespace EmmyLua.LanguageServer.Framework.Handler;

public class DocumentColorHandler : DocumentColorHandlerBase
{
    protected override Task<DocumentColorResponse> Handle(DocumentColorParams request, CancellationToken token)
    {
        Console.Error.WriteLine("DocumentColorHandler.Handle");

        var colorInformationList = new List<ColorInformation>
        {
            new ColorInformation
            {
                Range = new Range
                {
                    Start = new Position
                    {
                        Line = 0,
                        Character = 0
                    },
                    End = new Position
                    {
                        Line = 0,
                        Character = 1
                    }
                },
                Color = new Color(0, 0, 0, 0)
            }
        };
        return Task.FromResult(new DocumentColorResponse(colorInformationList));
    }

    protected override Task<ColorPresentationResponse> Resolve(ColorPresentationParams request, CancellationToken token)
    {
        Console.Error.WriteLine("DocumentColorHandler.Resolve");
        return Task.FromResult(new ColorPresentationResponse(new List<ColorPresentation>()));
    }

    public override void RegisterCapability(ServerCapabilities serverCapabilities,
        ClientCapabilities clientCapabilities)
    {
        serverCapabilities.ColorProvider = new DocumentColorOptions
        {
            WorkDoneProgress = true
        };
    }
}