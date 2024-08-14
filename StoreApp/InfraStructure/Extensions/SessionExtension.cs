using System.Text.Json;

namespace StoreApp.InfraStructure.Extensions
{
    public static class SessionExtension
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            //objeye bağlı olarak çalışmaktadır
            session.SetString(key,JsonSerializer.Serialize(value));
        }
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            //tipe bağlı olarak çalışmaktadır
            session.SetString(key,JsonSerializer.Serialize(value));
        }

        public static T? GetJson<T>(this ISession session, string key)
        {
            var data = session.GetString(key);
            return data is null ? default(T) : JsonSerializer.Deserialize<T>(data);
        }
    }
}