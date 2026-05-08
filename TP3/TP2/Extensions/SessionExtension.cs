namespace TP2.Extensions;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

public static class SessionExtensions // je doit conserver en session une List<int>, je ne sais pas quoi faire
{
    public static void Set<T>(this ISession session, string key, T value)
    {
        session.SetString(key, JsonSerializer.Serialize(value));
    }

    public static T Get<T>(this ISession session, string key)
    {
        var value = session.GetString(key);
        return value == null ? default : JsonSerializer.Deserialize<T>(value); // pas sur, j'ai réutiliser le code du devoir, checker sa fonction pour comprendre
    }
}
