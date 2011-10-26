using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Script.Serialization;

namespace GithubSharp.Core.Base
{
    internal static class JsonConverter
    {
        /// <summary>
        /// Serializes the object to a Json string 
        /// </summary>
        internal static string ToJson<T>(this T Obj)
        {
            return new JavaScriptSerializer().Serialize(Obj);
        }

        /// <summary>
        /// Deserializes
        /// </summary>
        /// <returns></returns>
        internal static T FromJson<T>(string Json)
        {
            if (string.IsNullOrEmpty(Json))
                throw new ArgumentNullException("Json");

            return new JavaScriptSerializer().Deserialize<T>(Json);
        }
    }
}