using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GithubSharp.Core.Base
{
    internal static class JsonConverter
    {
        // The JavaScriptSerializer type was marked as obsolete prior to .NET Framework 3.5 SP1
#pragma warning disable 0618

        /// <summary>
        /// Serializes the object to a Json string 
        /// </summary>
        internal static string ToJson(this object obj)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(obj);
        }

        /// <summary>
        /// Deserializes
        /// </summary>
        /// <returns></returns>
        internal static T FromJson<T>(string Json)
        {
            if (string.IsNullOrEmpty(Json))
                throw new ArgumentNullException("Json");
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Deserialize<T>(Json);
        }

        internal static object FromJson(string Json)
        {
            if (string.IsNullOrEmpty(Json))
                throw new ArgumentNullException("Json");
            return FromJson<object>(Json);
        }

#pragma warning restore 0618
    }
}
