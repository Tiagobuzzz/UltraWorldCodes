namespace UnityEngine
{
    public static class JsonUtility
    {
        public static string ToJson<T>(T obj) => System.Text.Json.JsonSerializer.Serialize(obj);
        public static T? FromJson<T>(string json) => System.Text.Json.JsonSerializer.Deserialize<T>(json);
    }
}
