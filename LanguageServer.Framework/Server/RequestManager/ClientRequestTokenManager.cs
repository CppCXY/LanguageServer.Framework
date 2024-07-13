using System.Collections.Concurrent;
using EmmyLua.LanguageServer.Framework.Protocol.Model.Union;

namespace EmmyLua.LanguageServer.Framework.Server.RequestManager;

public class ClientRequestTokenManager
{
    private ConcurrentDictionary<int, CancellationTokenSource> _intRequestTokens = new();
    private ConcurrentDictionary<string, CancellationTokenSource> _stringRequestTokens = new();

    public CancellationToken Create(StringOrInt id)
    {
        if (id.StringValue is null)
        {
            var token = new CancellationTokenSource();
            _intRequestTokens[id.IntValue] = token;
            return token.Token;
        }
        else
        {
            var token = new CancellationTokenSource();
            _stringRequestTokens[id.StringValue] = token;
            return token.Token;
        }
    }

    public void ClearToken(StringOrInt id)
    {
        if (id.StringValue is null)
        {
            _intRequestTokens.TryRemove(id.IntValue, out _);
        }
        else
        {
            _stringRequestTokens.TryRemove(id.StringValue, out _);
        }
    }

    public void CancelToken(StringOrInt id)
    {
        if (id.StringValue is null)
        {
            if (_intRequestTokens.TryRemove(id.IntValue, out var token))
            {
                token.Cancel();
            }
        }
        else
        {
            if (_stringRequestTokens.TryRemove(id.StringValue, out var token))
            {
                token.Cancel();
            }
        }
    }
}
