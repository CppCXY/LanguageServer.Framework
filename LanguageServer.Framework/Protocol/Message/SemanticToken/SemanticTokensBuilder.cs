using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.SemanticToken;

public class SemanticTokensBuilder
{
    private Dictionary<string, int> TokenTypeToId { get; } = new();

    private Dictionary<string, int> TokenModifierToId { get; } = new();

    public class SemanticTokenData
    {
        public Position Position { get; set; }
        public int Length { get; set; }
        public int TokenType { get; set; }
        public int Modifiers { get; set; }
    }

    private List<SemanticTokenData> Data { get; } = new();

    public SemanticTokensBuilder(List<string> tokenTypes, List<string> tokenModifiers)
    {
        for (var i = 0; i < tokenTypes.Count; i++)
        {
            TokenTypeToId[tokenTypes[i]] = i;
        }

        for (var i = 0; i < tokenModifiers.Count; i++)
        {
            TokenModifierToId[tokenModifiers[i]] = i;
        }
    }

    public void Push(Position startPosition, int length, string tokenType, string modifiers)
    {
        var tokenTypeIndex = TokenTypeToId[tokenType];
        var tokenModifierIndex = TokenModifierToId[modifiers];
        Data.Add(new SemanticTokenData
        {
            Position = startPosition,
            Length = length,
            TokenType = tokenTypeIndex,
            Modifiers = tokenModifierIndex
        });
    }

    public List<uint> Build()
    {
        var result = new List<uint>();
        // sort
        Data.Sort((a, b) =>
        {
            if (a.Position.Line == b.Position.Line)
            {
                return a.Position.Character - b.Position.Character;
            }

            return a.Position.Line - b.Position.Line;
        });


        var prevLine = 0;
        var prevCh = 0;
        foreach (var semanticTokenData in Data)
        {
            var line = semanticTokenData.Position.Line;
            var ch = semanticTokenData.Position.Character;
            var deltaLine = line - prevLine;

            result.Add((uint)deltaLine);
            if (deltaLine != 0)
            {
                prevCh = 0;
            }

            var deltaCh = ch - prevCh;
            result.Add((uint)deltaCh);
            result.Add((uint)semanticTokenData.Length);
            result.Add((uint)semanticTokenData.TokenType);
            result.Add((uint)semanticTokenData.Modifiers);
            prevLine = line;
            prevCh = ch;
        }

        return result;
    }
}
