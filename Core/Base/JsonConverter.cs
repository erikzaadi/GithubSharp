using System;

namespace GithubSharp.Core.Base
{
    internal static class JsonConverter
    {
        /// <summary>
        /// Serializes the object to a Json string 
        /// </summary>
        internal static string ToJson<T>(this T Obj)
        {
            return ServiceStack.Text.JsonSerializer.SerializeToString<T>(Obj);
        }

        internal static byte[] ToJsonBytes<T>(this T TObj)
        {
            var jsonString = ToJson<T>(TObj);
            return System.Text.Encoding.UTF8.GetBytes(jsonString);
        }

        /// <summary>
        /// Deserializes
        /// </summary>
        /// <returns></returns>
        internal static T FromJson<T>(string Json)
        {
            if (string.IsNullOrEmpty(Json))
                throw new ArgumentNullException("Json");
            return ServiceStack.Text.JsonSerializer.DeserializeFromString<T>(Json);
        }
    }
}