using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace GithubSharp.Core.Models.Internal
{
    [Serializable]
    internal class JsonSimpleDictionary : ISerializable
    {
        public Dictionary<string, string> Dict = new Dictionary<string, string>();

        public JsonSimpleDictionary(SerializationInfo info, StreamingContext context)
        {
            foreach (var entry in info)
            {
                Dict.Add(entry.Name, (string)entry.Value);
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException("JsonSimpleDict.GetObjectData: Called. Should never happpen.");
        }
    }
}
