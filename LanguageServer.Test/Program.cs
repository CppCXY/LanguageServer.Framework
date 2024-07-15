﻿using System.Net;
using System.Net.Sockets;
using EmmyLua.LanguageServer.Framework.Handler;
using EmmyLua.LanguageServer.Framework.Server;


Stream? input = null;
Stream? output = null;

if (args.Length > 0)
{
    var port = int.Parse(args[0]);
    var tcpServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    var ipAddress = new IPAddress(new byte[] { 127, 0, 0, 1 });
    EndPoint endPoint = new IPEndPoint(ipAddress, port);
    tcpServer.Bind(endPoint);
    tcpServer.Listen(1);

    var languageClientSocket = tcpServer.Accept();
    var networkStream = new NetworkStream(languageClientSocket);
    input = networkStream;
    output = networkStream;
}
else
{
    input = Console.OpenStandardInput();
    output = Console.OpenStandardOutput();
}

var ls = LanguageServer.From(input, output);
ls.OnInitialize((c, s) =>
{
    s.Name = "EmmyLua.Test";
    s.Version = "1.0.0";
    Console.Error.WriteLine("initialize");
});
ls.OnInitialized((c) => { Console.Error.WriteLine("initialized"); });
ls.AddHandler(new TextDocumentHandler(ls));
ls.AddHandler(new DeclarationHandler());
ls.AddHandler(new DefinitionHandler());
ls.AddHandler(new ImplementationHandler());
ls.AddHandler(new TypeDefinitionHandler());
ls.AddHandler(new CallHierarchyHandler());
ls.AddHandler(new CompletionHandler());
ls.AddHandler(new HoverHandler());
ls.AddHandler(new SignatureHelpHandler());
ls.AddHandler(new DocumentHighlightHandler());
ls.AddHandler(new DocumentSymbolHandler());
ls.AddHandler(new CodeActionHandler());
ls.AddHandler(new CodeLensHandler());
ls.AddHandler(new DocumentLinkHandler());
ls.AddHandler(new DocumentColorHandler());
ls.AddHandler(new DocumentFormattingHandler());
ls.AddHandler(new RenameHandler());
ls.AddHandler(new FoldingRangeHandler());
ls.AddHandler(new ExecuteCommandHandler(ls));
ls.AddHandler(new SelectionRangeHandler());
ls.AddHandler(new DidChangeWatchFilesHandler());
await ls.Run();