using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace GithubSharp.Core.Base
{
    internal static class JsonConverter
    {
        /// <summary>
        /// Serializes the object to a Json string 
        /// </summary>
        internal static string ToJson<T>(this T Obj)
        {
            var serializer = new DataContractJsonSerializer(typeof (T));
            using (var ms = new MemoryStream())
            {
                serializer.WriteObject(ms, Obj);
                string ret = Encoding.Default.GetString(ms.ToArray());
                return ret;
            }
        }

        /// <summary>
        /// Deserializes
        /// </summary>
        /// <returns></returns>
        internal static T FromJson<T>(string Json)
        {
            if (string.IsNullOrEmpty(Json))
                throw new ArgumentNullException("Json");

            var serializer = new DataContractJsonSerializer(typeof (T));
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(Json)))
                return (T) serializer.ReadObject(ms);
        }
    }
}